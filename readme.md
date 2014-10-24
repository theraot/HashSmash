---
HashSmash
---

This is a tool for ease of computing the MD5 of multiple files.

This tool takes a directory for input and a file for output. This output file will have a list of all files and their corresponding MD5 hash.

Having a list of all the MD5 makes it easier to find a file by it's MD5 - this is the intention behind HashSmash.

The output format has each file in a separate line, and each line has the following form:

    <full path of the file> tab character <computed MD5>

Note: The computed MD5 value will be in hexadecimal form using lower caps letters.

This format should be easy to import into any spreadsheet software such as LibreOffice Calc or Microsoft Excel, allowing for more more interesting functionality such as looking for possible duplicate files.

Usage: `HashSmash.exe <directory path> <result file path>`

Binary Downloads: http://www.4shared.com/folder/2YjW1Z8L/HashSmash.html