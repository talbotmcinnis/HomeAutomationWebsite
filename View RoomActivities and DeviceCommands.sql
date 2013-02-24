select R.RoomName, A.Activity, RA.Id from Rooms R
INNER JOIN RoomActivities RA ON RA.RoomId = R.Id
INNER JOIN Activities A ON RA.ActivityId=A.Id;

select D.DeviceName, DC.Name, DC.Id from Devices D
INNER JOIN DeviceCommands DC ON DC.DeviceId = D.Id;