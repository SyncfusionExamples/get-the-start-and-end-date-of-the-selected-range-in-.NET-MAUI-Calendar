using Syncfusion.Maui.Calendar;

namespace DateRangeSelection
{
    public class CalendarBehavior : Behavior<SfCalendar>
    {
        private SfCalendar sfCalendar;
        private DateTime startDate;
        private DateTime endDate;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            this.sfCalendar = bindable;
            this.sfCalendar.SelectionChanged += SfCalendar_SelectionChanged;
        }

        private void SfCalendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (this.sfCalendar.SelectedDateRange != null)
            {
                startDate = (DateTime)this.sfCalendar.SelectedDateRange.StartDate;
                if (this.sfCalendar.SelectedDateRange.EndDate != null)
                {
                    endDate = (DateTime)this.sfCalendar.SelectedDateRange.EndDate;
                }
                else
                {
                    endDate = (DateTime)this.sfCalendar.SelectedDateRange.StartDate;
                }

                App.Current.MainPage.DisplayAlert("StartDate:" + " " + startDate.ToString("dd/MM/yyyy"), "EndDate:" + " " + endDate.ToString("dd/MM/yyyy"), "OK");
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.sfCalendar != null)
            {
                this.sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }

            this.sfCalendar = null;
        }
    }
}
