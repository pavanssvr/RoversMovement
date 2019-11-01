# RoversMovement
Move the Rover based on provided signals

Project has been implemented with Asp.Net core 2.0

'GetRoversCurrentPosition' is the POST WEB API implemented and can be be access through http://localhost:60891/api/rover/GetRoversCurrentPosition
once application is running.

by passing the below json formatted inputs.

Below are the sample inputs and API has been tested through Postman by passing the inputs in json format

{
	"plateau":"55",
	"position":"12N",
	"movementSignals":"LMLMLMLMM"
}

{
	"plateau":"55",
	"position":"33E",
	"movementSignals":"MMRMMRMRRM"
}
