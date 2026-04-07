import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.io.FileWriter;

public class DbToCsvReport {

    // Database credentials
    private static final String DB_URL = "jdbc:mysql://localhost:3306/companydb";
    private static final String DB_USER = "root";
    private static final String DB_PASSWORD = "password";

    public static void main(String[] args) {

        String csvFile = "employees_report.csv";
        String query = "SELECT id, name, department, salary FROM employees";

        try (
            Connection conn = DriverManager.getConnection(DB_URL, DB_USER, DB_PASSWORD);
            PreparedStatement stmt = conn.prepareStatement(query);
            ResultSet rs = stmt.executeQuery();
            FileWriter writer = new FileWriter(csvFile)
        ) {
            // Write CSV header
            writer.append("Employee ID,Name,Department,Salary\n");

            // Write records
            while (rs.next()) {
                writer.append(rs.getInt("id") + ",");
                writer.append(rs.getString("name") + ",");
                writer.append(rs.getString("department") + ",");
                writer.append(rs.getDouble("salary") + "\n");
            }

            System.out.println("CSV report generated successfully: " + csvFile);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
