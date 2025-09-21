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

//Question 2

Programs
	.Select(x => new
	{
		School = x.Schools.SchoolCode.ToUpper() == "SAMIT" ? "School of Advanced Media and IT" : x.Schools.SchoolCode.ToUpper() == "SEET" ? "School of Electrical Enginerring Tech" : "Unknown",
		Program = x.ProgramName,
		RequiredCourseCount = x.ProgramCourses.Count(pc => pc.Required),
		OptionalCourseCount = x.ProgramCourses.Count(pc => !pc.Required)
	})
	.Where(x => x.RequiredCourseCount >= 22)
	.OrderBy(x => x.Program)
	.Dump();

//Question 3

Students
	.Where(x => x.StudentPayments.Count() == 0 && x.CountryCode.ToUpper() != "CA")
	.OrderBy(x => x.LastName)
	.Select(x => new
	{
		StudentNumber = x.StudentNumber,
		CountryName = x.Countries.CountryName,
		FullName = $"{x.FirstName} {x.LastName}",
		ClubMemebershipCount = x.ClubMembers.Count() == 0 ? "None" : x.ClubMembers.Count().ToString()
	})
	.Dump();
	
//Question 4

Employees
	.Where(x => x.PositionID == 4 && x.ReleaseDate == null && x.ClassOfferings.Count() > 0)
	.OrderByDescending(x => x.ClassOfferings.Count())
	.ThenBy(x => x.LastName)
	.Select(x => new
	{
		ProgramName = x.Program.ProgramName,
		FullName = $"{x.FirstName} {x.LastName}",
		WorkLoad = x.ClassOfferings.Count() > 24 ? "High" : x.ClassOfferings.Count() > 8 ? "Med" : "Low"
	})
	.Dump();
	
