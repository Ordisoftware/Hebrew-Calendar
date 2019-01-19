using System.Collections.Generic;

namespace Calendar.NET
{
    internal class EventComparer : IComparer<IEvent>
    {
        public int Compare(IEvent x, IEvent y)
        {
            int rankComp = x.Rank.CompareTo(y.Rank);

            if (rankComp == 0)
            {
                int comp1 = x.Date.Day.CompareTo(y.Date.Day);

                if (comp1 == 0)
                {
                    int comp2 = x.Date.Month.CompareTo(y.Date.Month);

                    if (comp2 == 0)
                    {
                        int comp3 = x.Date.Year.CompareTo(y.Date.Year);

                        if (comp3 == 0)
                        {
                            int comp4 = x.Date.Hour.CompareTo(y.Date.Hour);

                            if (comp4 == 0)
                            {
                                int comp5 = x.Date.Minute.CompareTo(y.Date.Minute);

                                if (comp5 == 0)
                                {
                                    return x.Rank.CompareTo(y.Rank);
                                }

                                return comp5;
                            }

                            return comp4;
                        }
                        return comp3;
                    }

                    return comp2;
                }

                return comp1;
            }
            return rankComp;
        } 
    }
}
