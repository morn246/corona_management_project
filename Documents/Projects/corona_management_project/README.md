# HMO Management System

# How to Run the web application?

## download from git the project 
1. the project from visual studio 2019 (asp.net web applicaion)

## open the project from vs
1. name project: "corona_management_project" open it
2. the project in visual studio 2019 opened
3. folow the steps before run

## download and open  sql server
2. download Download SSMS:
Link: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
2. and then open SQL_server Mangement Studio

## create DB  in sql server
1. open project and open file called "script_corona_db.sql"
2. open SQL_server Mangement Studio:
	1. open a "Query Window" in SQL_server Mangement Studio
3. copy  script from  "script_corona_db.sql" in vs
4. paste script from query in sql server
5. Execute the query it in SQL_server
6. Now created DB in sql server.

## Run Start without Dubeg
1. runing
2. in home page you have 2 buttons:
	1. table of Members in HMO:
	2. Queries:
	![image](./corona_management_project/screenshots/1.JPG)
	

## if you press Button of Members in HMO:
1. display of members just id and full nem
![image](./corona_management_project/screenshots/2.JPG)
2. You can add member or delete member or more info of one from members
3.  press "add member":
	1. enter fields follows the format 
	![image](./corona_management_project/screenshots/3.JPG)
	2. press "save data" 
	![image](./corona_management_project/screenshots/5.JPG)
	![image](./corona_management_project/screenshots/6.JPG)
3.  press "delete" one from members:
	1. you can see the members in table deleted 
	
4. press "more":
	1. you can see information about the chosen member: 
	![image](./corona_management_project/screenshots/7.JPG)

		1. presonal detalies:
			1.1. You can see Personal details such as address or phone 	
			![image](./corona_management_project/screenshots/8.JPG)

			1.2 You  can edit the details and save 			
			![image](./corona_management_project/screenshots/9.JPG)

		2.The vaccinations:
			1. You can see all the vaccinations the member did
			![image](./corona_management_project/screenshots/10.JPG)

			2. You can add another vaccine (up to 4 vaccines)			
			![image](./corona_management_project/screenshots/11.JPG)

			2. You can edit The type of vaccine 			
			3. You can delete a vaccine 
			
		3. Corona:
			3.1 You can see the date he got corona virus and recovery date (if there is a member)
			![image](./corona_management_project/screenshots/15.JPG)

			3.2.You can add the dates (one of them or both)- But if there are already dates, you can't add more			
			![image](./corona_management_project/screenshots/16.JPG)

			3.3.You can edit one of the dates
			![image](./corona_management_project/screenshots/12.JPG)

			![image](./corona_management_project/screenshots/13.JPG)

			3.4.You can delete the dates
			![image](./corona_management_project/screenshots/14.JPG)

		4. You can close the popup window and  select another friend whose details you want to know

## if you press Button Queries (BONUS):
1. 2 queries:
![image](./corona_management_project/screenshots/17.JPG)

	1. query return The amount of people not vaccinated at all
		1. press it and display the number:
		![image](./corona_management_project/screenshots/18.JPG)

	2.Shows the graph of the amount of vaccinated people according to each day of the last month
		1. press and popup window open :
		![image](./corona_management_project/screenshots/19.JPG)
		2.and press to see the graph:
		![image](./corona_management_project/screenshots/20.JPG)
5. Done :)

	

