import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;
import java.io.*;
import java.util.Base64;

public class CsvEncryptionExample {

    // AES secret key (16 characters = 128-bit)
    private static final String SECRET_KEY = "MySecretKey12345";

    public static void main(String[] args) throws Exception {

        String encryptedFile = "employees_encrypted.csv";
        String decryptedFile = "employees_decrypted.csv";

        writeEncryptedCsv(encryptedFile);
        readAndDecryptCsv(encryptedFile, decryptedFile);
    }

    static void writeEncryptedCsv(String filePath) throws Exception {

        try (FileWriter writer = new FileWriter(filePath)) {

            writer.write("ID,Name,Department,Salary,Email\n");

            writer.write("1,Aditya,IT," +
                    encrypt("60000") + "," +
                    encrypt("aditya@gmail.com") + "\n");

            writer.write("2,Rahul,HR," +
                    encrypt("45000") + "," +
                    encrypt("rahul@yahoo.com") + "\n");

            writer.write("3,Neha,Finance," +
                    encrypt("55000") + "," +
                    encrypt("neha@company.com") + "\n");
        }

        System.out.println("Encrypted CSV written successfully");
    }

    static void readAndDecryptCsv(String encryptedFile, String outputFile) throws Exception {

        try (
            BufferedReader reader = new BufferedReader(new FileReader(encryptedFile));
            FileWriter writer = new FileWriter(outputFile)
        ) {
            // Write header
            writer.write(reader.readLine() + "\n");

            String line;
            while ((line = reader.readLine()) != null) {

                String[] data = line.split(",");

                String decryptedSalary = decrypt(data[3]);
                String decryptedEmail = decrypt(data[4]);

                writer.write(
                        data[0] + "," +
                        data[1] + "," +
                        data[2] + "," +
                        decryptedSalary + "," +
                        decryptedEmail + "\n"
                );
            }
        }

        System.out.println("Decrypted CSV generated successfully");
    }

    static String encrypt(String value) throws Exception {
        Cipher cipher = Cipher.getInstance("AES");
        SecretKeySpec key = new SecretKeySpec(SECRET_KEY.getBytes(), "AES");
        cipher.init(Cipher.ENCRYPT_MODE, key);

        byte[] encryptedBytes = cipher.doFinal(value.getBytes());
        return Base64.getEncoder().encodeToString(encryptedBytes);
    }

    static String decrypt(String encryptedValue) throws Exception {
        Cipher cipher = Cipher.getInstance("AES");
        SecretKeySpec key = new SecretKeySpec(SECRET_KEY.getBytes(), "AES");
        cipher.init(Cipher.DECRYPT_MODE, key);

        byte[] decodedBytes = Base64.getDecoder().decode(encryptedValue);
        return new String(cipher.doFinal(decodedBytes));
    }
}
