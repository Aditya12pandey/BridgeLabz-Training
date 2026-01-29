import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.List;

public class CsvToStudent {

    // Student class (merged in same file)
    static class Student {
        private int id;
        private String name;
        private int marks;
        private String department;

        public Student(int id, String name, int marks, String department) {
            this.id = id;
            this.name = name;
            this.marks = marks;
            this.department = department;
        }

        @Override
        public String toString() {
            return "Student [ID=" + id +
                   ", Name=" + name +
                   ", Marks=" + marks +
                   ", Department=" + department + "]";
        }
    }

    public static void main(String[] args) {
        String filePath = "students.csv";
        List<Student> students = new ArrayList<>();

        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {

            // Skip header row
            br.readLine();

            String line;
            while ((line = br.readLine()) != null) {
                String[] data = line.split(",");

                int id = Integer.parseInt(data[0]);
                String name = data[1];
                int marks = Integer.parseInt(data[2]);
                String department = data[3];

                students.add(new Student(id, name, marks, department));
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        // Print all students
        for (Student s : students) {
            System.out.println(s);
        }
    }
}
