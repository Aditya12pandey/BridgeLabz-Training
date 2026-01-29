import java.io.BufferedReader;
import java.io.FileReader;
import java.util.HashSet;
import java.util.Set;

public class DetectDuplicateCsv {

    public static void main(String[] args) {
        String filePath = "employees.csv";

        Set<String> seenIds = new HashSet<>();

        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {

            // Skip header
            br.readLine();

            String line;
            while ((line = br.readLine()) != null) {
                String[] data = line.split(",");

                String id = data[0];

                // If ID already exists, it's a duplicate
                if (!seenIds.add(id)) {
                    System.out.println("Duplicate Record Found:");
                    System.out.println(line);
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
