package main

import (
	"fmt"
	"log"
	"os"
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

	for i := range rows {
		t := rows[i]
		log.Println("Importing", t.Id())
		// todo: actual importing
	}

	log.Println("Importing complete. Press any key to exit.")
	fmt.Scanln()
}
