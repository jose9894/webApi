using MenuApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MenuApiV2.Data
{
    public static class FoodAppDbSeeder
    {
     //ret data igennem iforhold til trips som mangler tripdetails
        public static void Seed(FoodAppDbContext context)
        {
            context.Database.EnsureCreated();

            // context.TripDetails.RemoveRange(context.TripDetails);
            // context.Trips.RemoveRange(context.Trips);
            // context.OrderDetails.RemoveRange(context.OrderDetails);
            // context.Orders.RemoveRange(context.Orders);
            // context.Ratings.RemoveRange(context.Ratings);
            // context.Meals.RemoveRange(context.Meals);
            // context.Cooks.RemoveRange(context.Cooks);
            // context.Customers.RemoveRange(context.Customers);
            // context.DeliveryCyclists.RemoveRange(context.DeliveryCyclists);

            // context.SaveChanges();

            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Cook', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Meal', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Customer', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Delivery_Cyclist', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[Order]', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Trip', RESEED, 0)");
            // context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Rating', RESEED, 0)");


            if (!context.Cooks.Any())
            {
                // sletter alt data

                // 1. Cooks
                var cooks = new List<Cook>
                {
                    new Cook { Name = "Noah", PhoneNr = "+45 71555080", Address = "Finlands gade 17, 8200 Aarhus N",Certificate = true},
                    new Cook { Name = "Helle", PhoneNr = "+45 88887777", Address = "Nørregade 10, 8000 Aarhus" , Certificate = true},
                    new Cook { Name = "Lars", PhoneNr = "+45 12345678", Address = "Vesterbrogade 50, 1620 København V", Certificate = true }
                };
                context.Cooks.AddRange(cooks);
                context.SaveChanges();

                // 2. Meals
                var meals = new List<Meal>
                {
                    new Meal { Name = "Pasta", Qty = 3, Price = 30, TimeStart = DateTime.Parse("2023-01-01 11:30"), TimeEnd = DateTime.Parse("2023-01-01 12:30"), CookId = cooks[0].CId },
                    new Meal { Name = "Romkugle", Qty = 10, Price = 3, TimeStart = DateTime.Parse("2023-01-01 08:00"), TimeEnd = DateTime.Parse("2023-01-01 12:30"), CookId = cooks[0].CId },
                    new Meal { Name = "Lemonade", Qty = 5, Price = 15, TimeStart = DateTime.Parse("2023-01-01 10:00"), TimeEnd = DateTime.Parse("2023-01-01 15:00"), CookId = cooks[1].CId },
                    new Meal { Name = "Salad", Qty = 7, Price = 25, TimeStart = DateTime.Parse("2023-01-01 11:00"), TimeEnd = DateTime.Parse("2023-01-01 14:00"), CookId = cooks[2].CId },
                    new Meal { Name = "Burger", Qty = 6, Price = 50, TimeStart = DateTime.Parse("2023-01-01 11:00"), TimeEnd = DateTime.Parse("2023-01-01 14:00"), CookId = cooks[0].CId }

                };
                context.Meals.AddRange(meals);
                context.SaveChanges();
                // 3. Customers
                var customers = new List<Customer>
                {
                    new Customer { PhoneNr = "+45 11112222", Address = "Møllestien 5, 8000 Aarhus", PaymentOpt = "Card" },
                    new Customer { PhoneNr = "+45 33334444", Address = "Ny Munkegade 118, 8200 Aarhus", PaymentOpt = "Mobilepay" },
                    new Customer { PhoneNr = "+45 55556666", Address = "Skt. Knuds Torv 3, 5000 Odense", PaymentOpt = "Card" },
                    new Customer { PhoneNr = "+45 77778888", Address = "Banegårdspladsen 2, 8000 Aarhus", PaymentOpt = "Mobilepay" }
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();

                // 4. DeliveryCyclists
                var cyclists = new List<DeliveryCyclist>
                {
                    new DeliveryCyclist { PhoneNr = "+45 22223333", BikeType = "Bicycle" },
                    new DeliveryCyclist { PhoneNr = "+45 44445555", BikeType = "E-bike" },
                    new DeliveryCyclist { PhoneNr = "+45 66667777", BikeType = "Scooter" }
                };
                context.DeliveryCyclists.AddRange(cyclists);
                context.SaveChanges();

                // 5. Orders
                var orders = new List<Order>
                {
                    new Order { ODate = DateTime.Parse("2023-06-15 11:45:00"), CId = customers[0].CId },
                    new Order { ODate = DateTime.Parse("2023-07-20 12:05:00"), CId = customers[1].CId },
                    new Order { ODate = DateTime.Parse("2023-08-10 13:15:00"), CId = customers[2].CId },
                    new Order { ODate = DateTime.Parse("2023-09-05 12:10:00"), CId = customers[3].CId }
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();

                // 6. OrderDetails
                var orderDetails = new List<OrderDetail>
                {
                    new OrderDetail { OId = orders[0].OId, MId = meals[0].MId, Qty = 2 },
                    new OrderDetail { OId = orders[0].OId, MId = meals[1].MId, Qty = 4 },
                    new OrderDetail { OId = orders[0].OId, MId = meals[2].MId, Qty = 2 },
                    new OrderDetail { OId = orders[1].OId, MId = meals[1].MId, Qty = 1 },
                    new OrderDetail { OId = orders[1].OId, MId = meals[3].MId, Qty = 1 },
                    new OrderDetail { OId = orders[2].OId, MId = meals[1].MId, Qty = 3 },
                    new OrderDetail { OId = orders[2].OId, MId = meals[3].MId, Qty = 2 },
                    new OrderDetail { OId = orders[3].OId, MId = meals[4].MId, Qty = 2 },
                    new OrderDetail { OId = orders[3].OId, MId = meals[2].MId, Qty = 1 }
                };
                context.OrderDetails.AddRange(orderDetails);
                context.SaveChanges();

                // 7. Trips
                var trips = new List<Trip>
                {
                    new Trip { TripPay = 100, DcId = cyclists[0].DcId, OId = orders[0].OId, TTime = 30 },
                    new Trip { TripPay = 120, DcId = cyclists[1].DcId, OId = orders[1].OId, TTime = 45 },
                    new Trip { TripPay = 150, DcId = cyclists[2].DcId, OId = orders[2].OId, TTime = 35 },
                    new Trip { TripPay = 130, DcId = cyclists[0].DcId, OId = orders[3].OId, TTime = 40 }
                };
                context.Trips.AddRange(trips);
                context.SaveChanges();

                // 8. TripDetails
                var tripDetails = new List<TripDetail>
                {
                    new TripDetail { TId = trips[0].TId, TimeStamp = TimeOnly.Parse("12:00"), TripType = "Pickup", Address = "Finlands gade 17, 8200 Aarhus N" },
                    new TripDetail { TId = trips[0].TId, TimeStamp = TimeOnly.Parse("12:05"), TripType = "Pickup", Address = "Finlands gade 17, 8200 Aarhus N" },
                    new TripDetail { TId = trips[0].TId, TimeStamp = TimeOnly.Parse("12:15"), TripType = "Pickup", Address = "Nørregade 10, 8000 Aarhus" },
                    new TripDetail { TId = trips[0].TId, TimeStamp = TimeOnly.Parse("12:30"), TripType = "Delivery", Address = "Møllestien 5, 8000 Aarhus" },

                    new TripDetail { TId = trips[1].TId, TimeStamp = TimeOnly.Parse("12:00"), TripType = "Pickup", Address = "Finlands gade 17, 8200 Aarhus N"},
                    new TripDetail { TId = trips[1].TId, TimeStamp = TimeOnly.Parse("12:25"), TripType = "Pickup", Address = "Vesterbrogade 50, 1620 København V"},
                    new TripDetail { TId = trips[1].TId, TimeStamp = TimeOnly.Parse("12:45"), TripType = "Delivery", Address = "Ny Munkegade 118, 8200 Aarhus"},

                    new TripDetail { TId = trips[2].TId, TimeStamp = TimeOnly.Parse("12:00"), TripType = "Pickup", Address = "Finlands gade 17, 8200 Aarhus N"},
                    new TripDetail { TId = trips[2].TId, TimeStamp = TimeOnly.Parse("12:05"), TripType = "Pickup", Address = "Vesterbrogade 50, 1620 København V"},
                    new TripDetail { TId = trips[2].TId, TimeStamp = TimeOnly.Parse("12:35"), TripType = "Delivery", Address = "Skt. Knuds Torv 3, 5000 Odense"},

                    new TripDetail { TId = trips[3].TId, TimeStamp = TimeOnly.Parse("12:05"), TripType = "Pickup", Address = "Finlands gade 17, 8200 Aarhus N"},
                    new TripDetail { TId = trips[3].TId, TimeStamp = TimeOnly.Parse("12:15"), TripType = "Pickup", Address = "Nørregade 10, 8000 Aarhus"},
                    new TripDetail { TId = trips[3].TId, TimeStamp = TimeOnly.Parse("12:40"), TripType = "Delivery", Address = "Banegårdspladsen 2, 8000 Aarhus"},
                };
                context.TripDetails.AddRange(tripDetails);
                context.SaveChanges();

                // 9. Ratings
                var ratings = new List<Rating>
                {
                    new Rating { CId = customers[0].CId, CookId = cooks[0].CId, DcId = cyclists[0].DcId, OId = orders[0].OId, CStars = 5, DcStars = 5 },
                    new Rating { CId = customers[1].CId, CookId = cooks[0].CId, DcId = cyclists[1].DcId, OId = orders[1].OId, CStars = 4, DcStars = 4 },
                    new Rating { CId = customers[2].CId, CookId = cooks[2].CId, DcId = cyclists[2].DcId, OId = orders[2].OId, CStars = 5, DcStars = 5 },
                    new Rating { CId = customers[3].CId, CookId = cooks[0].CId, DcId = cyclists[0].DcId, OId = orders[3].OId, CStars = 5, DcStars = 4 }
                };
                context.Ratings.AddRange(ratings);
                context.SaveChanges();
            }
        }
    }
}
