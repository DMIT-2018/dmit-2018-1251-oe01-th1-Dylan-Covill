<Query Kind="Statements">
  <Connection>
    <ID>e9ca531c-76de-44d4-94b9-d2b9859883b4</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DYLAN-LAPTOP</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Question 1

ClubActivities
	.Where(x => x.StartDate.Value >= new DateTime(2025, 1, 1) && x.CampusVenue.Location.ToUpper() != "SCHEDULED ROOM" && x.Name != "BTECH CLUB MEETING")
	.Select(x => new
	{
		StartDate = x.StartDate,
		Location = x.CampusVenue.Location,
		Club = x.Club.ClubName,
		Activity = x.Name
	})
	.OrderBy(x => x.StartDate)
	.Dump();
