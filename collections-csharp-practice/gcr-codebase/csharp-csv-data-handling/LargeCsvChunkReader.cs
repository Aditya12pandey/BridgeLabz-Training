import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.List;

public class LargeCsvChunkReader {

    private static final int CHUNK_SIZE = 100;

    public static void main(String[] args) {
        String filePath = "largefile.csv";
        long totalRecordsProcessed = 0;

        List<String> chunk = new ArrayList<>(CHUNK_SIZE);

        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {

            // Skip header row
            br.readLine();

            String line;
            while ((line = br.readLine()) != null) {
                chunk.add(line);

                // When chunk reaches 100 lines, process it
                if (chunk.size() == CHUNK_SIZE) {
                    processChunk(chunk);
                    totalRecordsProcessed += chunk.size();
                    chunk.clear();

                    System.out.println("Records processed so far: " + totalRecordsProcessed);
                }
            }

            // Process remaining lines (< 100)
            if (!chunk.isEmpty()) {
                processChunk(chunk);
                totalRecordsProcessed += chunk.size();
                System.out.println("Records processed so far: " + totalRecordsProcessed);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        System.out.println("Total records processed: " + totalRecordsProcessed);
    }

    // Dummy processing logic (replace with real logic)
    private static void processChunk(List<String> lines) {
        for (String record : lines) {
            // Example: parse, validate, insert into DB, etc.
            // String[] columns = record.split(",");
        }
    }
}
