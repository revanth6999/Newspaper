# Newspaper API

Snap*.PNG files are the screenshots of formatted file.\
The solution consists of two APIs, Newspaper_Formatter and Neswspaper_Printer.\
The first API accepts the following:
1) An input text file which is to be formatted as a newspaper.
2) Newspaper properties such as,\
  a) Number of columns in a page\
  b) Number of rows in each column\
  c) Width of the page (in characters)\
  d) Inter column spacing (in characters\
  e) Readability level (Higher the readability level, lower will be the breakage of larger words and uses more paper)\
      - High (1), Medium (2) and Low (3)
      
      
![](snap1.png)

The first API assumes the following default inputs:\
  a) Number of columns in a page    - 3\
  b) Number of rows in each column  - 20 \
  c) Width of the page              - 80 characters\
  d) Inter column spacing           - 3 characters\
  e) Readability level              - Medium  
  
 The first API after converting the plain text into a formatted object of type Newspaper is serialized and passed to the second API.
 
 The second API deserializes and frames the object again. It returns the file path of the formatted text file.
 
 API form fields:
 
  a) Number of columns in a page          - noOfCols\
  b) Number of rows in each column        - noOfRows\
  c) Width of the page (in characters)    - widthOfPage\
  d) Inter column spacing (in characters  - columnSpacing\
  e) Readability level                    - readability Level

![](snap3.png)


