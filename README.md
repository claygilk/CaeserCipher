# CaeserCipher
C# implementation of a Caeser cipher

You can use this app to encode and decode messages using a ceaser cipher.

You can also input ciphert text that has been encoded with an unknown key, and the program will attempt to crack it.
This program uses a brute force approach, so this process can take a couple seconds.

## Usage

To build and run this project, first clone it from Github and navigate to the root of the project. Open a terminal and run the following:

Build

```sh
dotnet build CeaserCipher
```

Run

To back out of a menu, enter 'q' when prompted for 'plaintext' or 'ciphertext'

```sh
dotnet run --project CeaserCipher/CeaserCipher.csproj

### Ceaser Cipher ###
Choose an Option: 
1: Encode Message with Ceaser Cipher
2: Decode Message with Ceaser Cipher
3:  Crack Message with Ceaser Cipher

```
