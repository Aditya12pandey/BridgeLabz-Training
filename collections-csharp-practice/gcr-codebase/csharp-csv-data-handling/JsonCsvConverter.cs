import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.core.type.TypeReference;

import java.io.*;
import java.util.*;

public class JsonCsvConverter {

    // Student class
    static class Student {
        public int id;
        public String name;
        public int marks;
        public String department;

        public Student() {} // required for Jackson

        public Student(int id, String name, int marks, String department) {
            this.id = id;
            this.name = name;
            this.marks = marks;
            this.department = department;
        }
    }

    public static void main(String[] args) throws Exception {
        jsonToCsv("students.json", "students.csv");
        csvToJson("students.csv", "students_converted.json");
    }

    // ---------- JSON → CSV ----------
    static void jsonToCsv(String jsonFile, String csvFile) throws Exception {
        ObjectMapper mapper = new ObjectMapper();

        List<Student> students =
                mapper.readValue(new File(jsonFile),
                        new TypeReference<List<Student>>() {});

        try (FileWriter writer = new FileWriter(csvFile)) {
            writer.write("ID,Name,Marks,Department\n");

            for (Student s : students) {
                writer.write(s.id + "," + s.name + "," + s.marks + "," + s.department + "\n");
            }
        }

        System.out.println("JSON converted to CSV successfully");
    }

    static void csvToJson(String csvFile, String jsonFile) throws Exception {
        List<Student> students = new ArrayList<>();

        try (BufferedReader br = new BufferedReader(new FileReader(csvFile))) {

            br.readLine(); // skip header
            String line;

            while ((line = br.readLine()) != null) {
                String[] data = line.split(",");

                students.add(new Student(
                        Integer.parseInt(data[0]),
                        data[1],
                        Integer.parseInt(data[2]),
                        data[3]
                ));
            }
        }

        ObjectMapper mapper = new ObjectMapper();
        mapper.writerWithDefaultPrettyPrinter()
              .writeValue(new File(jsonFile), students);

        System.out.println("CSV converted back to JSON successfully");
    }
}
