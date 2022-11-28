using Microsoft.AspNetCore.Mvc.ModelBinding;
using projectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Utils
{

    public static class Utilities
    {

        public static int getDriverPreformance(VipContext _context, Driver driver)
        {
            /*Driver driver = _context.Driver.Find(DriverId);*/

            int tripCount = _context.Trips.Where(
                t => t.DriverId == driver.Id
                ).Count();

            int maintenanceCosts = _context.Maintenance.Where(
                m => m.BusId == driver.BusId
                ).Sum(m => m.MaintenanceCost);

            int salesTotals = _context.Sales.Where(
                s => s.BusId == driver.BusId
                ).Sum(s => s.Amount);
            Console.WriteLine("tripcount" + tripCount);
            Console.WriteLine("sales" + salesTotals);

            return (tripCount * salesTotals) - maintenanceCosts;
        }
        public static double getProfits(VipContext _context, Driver driver)
        {
            int salesTotals = _context.Sales.Where(
                s => s.BusId == driver.BusId
                ).Sum(s => s.Amount);


            int maintenanceCosts = _context.Maintenance.Where(
                m => m.BusId == driver.BusId
                ).Sum(m => m.MaintenanceCost);

            return (salesTotals - maintenanceCosts);
        }

        public static int GetMonthNum(string monthText) {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(monthText.ToLower());
            if (regex.IsMatch("january"))
            {
                return 1;
            } else if (regex.IsMatch("february"))
            {
                return 2;
            }
            else if(regex.IsMatch("march"))
            {
                return 3;
            } else if (regex.IsMatch("april"))
            {
                return 4;
            }
            else if(regex.IsMatch("may"))
            {
                return 5;
            } else if (regex.IsMatch("june"))
            {
                return 6;
            }
            else if(regex.IsMatch("july"))
            {
                return 7;
            } else if (regex.IsMatch("august"))
            {
                return 8;
            }
            else if(regex.IsMatch("september"))
            {
                return 9;
            } else if (regex.IsMatch("october"))
            {
                return 10;
            }
            else if(regex.IsMatch("november"))
            {
                return 11;
            } else if (regex.IsMatch("december"))
            {
                return 12;
            }

            return -1;
        }
        public static int getTotalMaintenances(VipContext _context, Trips trip)
        {
            int totalMaintenance = _context.Trips.Select(
               t => t.TripMaintenancecost
               ).Sum();

            return totalMaintenance ;
        }
        public static int getTotalSales(VipContext _context, Trips trip)
        {
            int totalSales = _context.Trips.Select(
               t => t.TripSales
               ).Sum();

            return totalSales;
        }
        public static int getAllProfits(VipContext _context, Trips trip)
        {
            int totalMaintenance = _context.Trips.Select(
                t => t.TripMaintenancecost
                ).Sum();


            int totalSales = _context.Trips.Select(
             t => t.TripSales
             ).Sum();


            return (totalSales - totalMaintenance);
        }
       public static int getTripCount(VipContext _context, Trips trip)
        {
            int totaltripCount = _context.Trips.Select(
               t => t.Id
               ).Count();

            return totaltripCount;
        }
        public static int getBusCount(VipContext _context, Trips trip)
        {
            int totalbusCount = _context.Trips.Select(
               t => t.BusId
               ).Count();

            return totalbusCount;
        }
        public static int getDriverCount(VipContext _context, Trips trip)
        {
            int totaldriverCount = _context.Trips.Select(
               t => t.DriverId
               ).Count();

            return totaldriverCount;
        }
        public static int getWeekNum(DateTime date)
        {
            int weeks = 0;
            int startDay = 1;
            int dayOfMonth = date.Day;
            int maxDaysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int weekNum = 0;

            for(int i = 0; i < (maxDaysInMonth + startDay); i++)
            {
                if((i % 7) == 0)
                {
                    weeks++;
                }
                if(dayOfMonth == (i - startDay + 1))
                {
                    weekNum = weeks;
                }
            }

            if(weekNum != 1)
            {
                return weekNum;
            } else
            {
                return weekNum;
            }
        }
    }
    
}