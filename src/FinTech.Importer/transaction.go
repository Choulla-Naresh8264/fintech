package main
import (
	"time"
)

type Transaction struct {
	Id       	string 				`json:"id" bson:"_id,omitempty"`
	Timestamp time.Time 		`json:"timestamp" bson:"Timestamp"`
	Amount 		float64 			`json:"amount" bson:"Amount"`
	FromAddress	 		string	`json:"fromAddress" bson:"FromAddress"`
	ToAddress		 		string	`json:"toAddress" bson:"ToAddress"`
}
