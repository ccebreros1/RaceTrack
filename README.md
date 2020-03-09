# RaceTrack
This is a .Net Core 3.1 MVC Race Track Simple Application


# How to use the application
There are a couple of steps that one needs to follow to add a vehicle to the racetrack. The steps are:
1. Add vehicle types (Truck and Car must be added)
2. Add Race Tracks
3. Add Races
4. Add Vehicles
5. Add Race Vehicles

# Road Map

The first version of the application is ready. While most functionality is in place not all of it is perfect yet.

The application currently was designed to fulfill the following requirements:

**The following set of business requirements should help you demonstrate the above:**

1. Present an always up-to-date listing of vehicles on the race track (Utilizing AJAX)
2. Present a single form to add vehicles to the race track. (Utilize a Type drop-down to determine which fields to show/hide, see inspections below)
3. A maximum of 5 vehicles can be on the race-track at any time.
4. Vehicles must pass an inspection prior to entering the track

**Next steps**

The next iteration of the application will focus on the bugs that are present on update of the Race Vehicles form. It will also include some visual improvements, as well as more unit tests for other test cases. Tables will change from static html generated to dynamicly pulled with pagination enabled. JQuery Datatables can be an option. For dropdowns will also be planning to update them from traditional dropdowns to select2 with infinite scrolling and pagination for better data retrieval.

Will add sorting of dropdowns alphabetically, as well as grids sorted more logically.

A SQL script with required data is also on the road map, for lookups to be there.

Instead of setting time intervals for the partial views to be retrieved, some SignalR could be a good idea so that we don't over saturate the server with db calls every x amount of time.

I am planning to build a Blazor version of this same app to test out this new technology.
