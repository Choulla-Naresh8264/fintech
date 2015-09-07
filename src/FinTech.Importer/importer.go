package main

import (
	"fmt"
	"log"
	"os"
	"labix.org/v2/mgo"
	"strconv"
	"time"
)

var(
	Server = "mongodb://localhost:27017"
	Database = "fintech"
	Collection = "transactions"
	TimeFormat = "2006-01-02 15:04:05"
)


func main() {

	if len(os.Args)<2 {
		fmt.Println("No file to import")
		return
	}

	inputFile:= os.Args[1]
	log.Println("Reading csv file", inputFile)

	rows, err := readInput(inputFile)
	if err != nil {
		return
	}
	log.Println("Read", len(rows), "rows, importing...")

	session, err := mgo.Dial(Server)
	if err != nil {
		return
	}

	transactions := session.DB(Database).C(Collection)

	for i := range rows {
		r := rows[i]
		t := Transaction{}
		t.Id = r.Id()
		t.Timestamp, err = time.Parse(TimeFormat, r.Timestamp())
		if err != nil {
			fmt.Println("Error while parsting transaction timestamp: ", err)
			continue
		}

		t.Amount, err = strconv.ParseFloat(r.Amount(), 64)

		t.From = r.From()
		t.To = r.To()

		log.Println("Importing", t.Id)
		err = transactions.Insert(&t)
		if err != nil {
			fmt.Println("Error while inserting transaction: ", err)
			continue
		}
	}

	log.Println("Importing complete. Press any key to exit.")
	fmt.Scanln()
}
