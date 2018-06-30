using System;

class DateModifier
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double CalculateDate()
    {
      return Math.Abs((this.StartDate-this.EndDate).TotalDays);
    }
}

