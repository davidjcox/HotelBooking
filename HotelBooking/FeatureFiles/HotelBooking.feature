
Feature: Book a hotel room
	The Hotel booking form website accepts valid (complete and correct) bookings for a fictional hotel.
	It does not provide feedback on what constitutes a valid booking. It only adds a booking if its criteria are met.
	The user can infer certain requirements from experience: names must contain letters and a set of accepted special
	characters, prices must be decimal, booking dates must only be from present day into the future, and that check-in
	must occur before check-out


Scenario: Create a valid hotel booking
	Given the user opens the Hotel booking form
	When the user creates a valid booking
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | true    | today_+12_days | today_+17_days |
	Then the booking should be added to the booking listing


Scenario: Delete a valid hotel booking
	Given the user opens the Hotel booking form
	When the user creates a valid booking
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Max       | Eisenhardt  | 753.1 | false   | today_+2_days  | today_+7_days  |
	And the user deletes that newly created booking
	Then the newly-created booking should be removed from the booking listing


Scenario: Create multiple valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple valid bookings
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | true    | today_+12_days | today_+17_days |
		| Max       | Eisenhardt  | 753.1 | false   | today_+2_days  | today_+7_days  |
		| James     | Howlett     | 951   | true    | today_+32_days | today_+39_days |
		| Scott     | Summers     | 159   | false   | today_+0_days  | today_+5_days  |
	Then all newly-created bookings should be added to the booking listing


Scenario: Delete multiple valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple valid bookings
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | false   | today_+12_days | today_+17_days |
		| Max       | Eisenhardt  | 753.1 | true    | today_+2_days  | today_+7_days  |
		| James     | Howlett     | 951   | false   | today_+32_days | today_+39_days |
		| Scott     | Summers     | 159   | true    | today_+0_days  | today_+5_days  |
	And the user deletes those newly-created valid bookings
	Then all newly-created bookings should be removed from the booking listing


Scenario: Delete the first of a block of multiple newly-created valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple valid bookings
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | true    | today_+12_days | today_+17_days |
		| Max       | Eisenhardt  | 753.1 | true    | today_+2_days  | today_+7_days  |
		| James     | Howlett     | 951   | flase   | today_+32_days | today_+39_days |
		| Scott     | Summers     | 159   | false   | today_+0_days  | today_+5_days  |
	And the user deletes the first booking of multiple newly-created bookings
	Then the first booking of the multiple newly-created bookings should be removed from the booking listing


Scenario: Delete a booking in the midst of a block of multiple newly-created valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple valid bookings
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | false   | today_+12_days | today_+17_days |
		| Max       | Eisenhardt  | 753.1 | false   | today_+2_days  | today_+7_days  |
		| James     | Howlett     | 951   | true    | today_+32_days | today_+39_days |
		| Scott     | Summers     | 159   | true    | today_+0_days  | today_+5_days  |
	And the user deletes one of the bookings in the midst of multiple newly-created bookings
	Then the booking in the midst of the multiple newly-created bookings should be removed from the booking listing


Scenario: Delete the last of a block of multiple newly-created valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple valid bookings
		| Firstname | Surname     | Price | Deposit | Checkin        | Checkout       |
		| Charles   | Xavier      | 357.9 | true    | today_+12_days | today_+17_days |
		| Max       | Eisenhardt  | 753.1 | false   | today_+2_days  | today_+7_days  |
		| James     | Howlett     | 951   | flase   | today_+32_days | today_+39_days |
		| Scott     | Summers     | 159   | true    | today_+0_days  | today_+5_days  |
	And the user deletes the last booking of multiple newly-created bookings
	Then the last booking in the multiple newly-created bookings should be removed from the booking listing


Scenario: Create multiple duplicate valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple duplicate valid bookings
		| Firstname    | Surname   | Price | Deposit | Checkin         | Checkout        |
		| Remy Etienne | LeBeau    | 9999  | true    | today_+212_days | today_+232_days |
	Then all newly-created duplicate bookings should be added to the booking listing


Scenario: Delete multiple duplicate valid hotel bookings
	Given the user opens the Hotel booking form
	When the user creates multiple duplicate valid bookings
		| Firstname    | Surname   | Price | Deposit | Checkin         | Checkout        |
		| Remy Etienne | LeBeau    | 9999  | false   | today_+500_days | today_+600_days |
	And the user deletes those newly-created duplicate valid bookings
	Then all newly-created duplicate bookings should be removed from the booking listing