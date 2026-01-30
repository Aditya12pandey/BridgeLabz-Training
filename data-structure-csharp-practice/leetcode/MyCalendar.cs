public class MyCalendar {
  private List<(int start, int end)> bookings;

  public MyCalendar() {
      bookings = new List<(int start, int end)>();
  }
  
  public bool Book(int startTime, int endTime) {
      // Check for overlap with existing bookings
      foreach (var (start, end) in bookings) {
          if (startTime < end && endTime > start) {
              return false; // overlap detected
          }
      }

      // No overlap → add booking
      bookings.Add((startTime, endTime));
      return true;
  }
}