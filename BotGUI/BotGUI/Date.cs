using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BotGUI
{
    // handles a simplified date. overloads operators for easy
    // comparison
    internal class Date
    {
        private static int[] day30 = { 4, 6, 9, 11 };
        private static int[] day31 = { 1, 3, 5, 7, 8, 10, 12 };
        public int year;
        public int month;
        public int day;
        public Date(int a, int b, int c)
        {
            year = a; month = b; day = c;
        }

        public static bool operator>(Date a, Date b)
        {
            return (a.year > b.year) ||
                (a.year == b.year && a.month > b.month) ||
                (a.year == b.year && a.month == b.month && a.day > b.day);
        }

        public static bool operator<(Date a, Date b)
        {
            return (a.year < b.year) ||
               (a.year == b.year && a.month < b.month) ||
               (a.year == b.year && a.month == b.month && a.day < b.day);
        }

        public static bool operator>=(Date a, Date b)
        {
            return (a.year >= b.year) ||
                (a.year == b.year && a.month >= b.month) ||
                (a.year == b.year && a.month == b.month && a.day >= b.day);
        }

        public static bool operator<=(Date a, Date b)
        {
            return (a.year <= b.year) ||
                (a.year == b.year && a.month <= b.month) ||
                (a.year == b.year && a.month == b.month && a.day <= b.day);
        }

        public static bool operator==(Date a, Date b)
        {
            return a.year == b.year && a.month == b.month && a.day == b.day;
        }

        public static bool operator!=(Date a, Date b)
        {
            return a.year != b.year || a.month != b.month || a.day != b.day;
        }

        public static Date operator++(Date a)
        {
            a.day++;
            bool incMonth = false;
            incMonth = incMonth || (day30.Contains(a.month) && a.day == 31);
            incMonth = incMonth || (day31.Contains(a.month) && a.day == 32);
            incMonth = incMonth || (a.month == 2 && isLeap(a.year) && a.day == 30);
            incMonth = incMonth || (a.month == 2 && !isLeap(a.year) && a.day == 29);
            if (incMonth)
            {
                a.day = 1;
                a.month++;
            }
            if (a.month == 13)
            {
                a.month = 1;
                a.year++;
            }
            return a;
        }

        public static Date operator--(Date a)
        {
            a.day--;
            if (a.day == 0)
            {
                a.month--;
                if (a.month == 0)
                {
                    a.year--;
                    a.month = 12;
                }
                if (day30.Contains(a.month))
                    a.day = 30;
                else if (day31.Contains(a.month))
                    a.day = 31;
                else if (a.month == 2 && isLeap(a.year))
                    a.day = 29;
                else if (a.month == 2 && !isLeap(a.year))
                    a.day = 28;
            }
            return a;
        }

        private static bool isLeap(int a)
        {
            return (a % 4 == 0) && (a % 100 != 0 || a % 400 == 0);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this == (Date)obj;
        }

        public override int GetHashCode()
        {
            return year * 10000 + month * 100 + day;
        }

        public Date clone()
        {
            return new Date(year, month, day);
        }

        public static Date parseDate(String s)
        {
            String[] fields = s.Split("-");
            return new Date(int.Parse(fields[0]), int.Parse(fields[1]), int.Parse(fields[2]));
        }
    }
}
