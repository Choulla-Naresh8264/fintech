package main

type Row struct {
	Fields []string
}

func (r Row) Id() string {
	return r.Fields[0]
}

func (r Row) Timestamp() string {
	return r.Fields[1]
}

func (r Row) Amount() string {
	return r.Fields[2]
}

func (r Row) From() string {
	return r.Fields[3]
}

func (r Row) To() string {
	return r.Fields[4]
}
