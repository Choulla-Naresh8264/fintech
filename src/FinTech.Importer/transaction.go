package main
import (
	"time"
)

type Transaction struct {
	Id       	string 				`json:"id" bson:"_id,omitempty"`
	Timestamp time.Time 		`json:"timestamp" bson:"timestamp"`
	Amount 		float64 			`json:"amount" bson:"amount"`
	From	 		string				`json:"from" bson:"from"`
	To		 		string				`json:"to" bson:"to"`
}
