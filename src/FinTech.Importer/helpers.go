package main

import (
	"encoding/csv"
	"io"
	"log"
	"os"
)

func readInput(fileName string) ([]Row, error) {
	file, err := os.Open(fileName)
	if err != nil {
		log.Printf("Error while reading the file. %v", err)
		return nil, err
	}
	defer file.Close()

	reader := csv.NewReader(file)
	reader.LazyQuotes = true
	reader.Comma = ','

	rows := []Row{}

	for {
		record, err := reader.Read()
		if err == io.EOF {
			break
		} else if err != nil {
			log.Println("Error while processing a row.", err)
			return nil, err
		}
		row := Row{}
		row.Fields = record
		rows = append(rows, row)
	}
	return rows, nil
}
