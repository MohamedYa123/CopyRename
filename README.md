# Automated-Phone-Copying-Checking-Renaming-Utility
Automated Phone Copying, Checking & Renaming Utility
I need a simple program that will copy files from one location (mobile phone iOS or Android plugged into the PC via USB) to another location (usually PC drive) and rename the files before copying them to a second location (usually a network drive).

The most important aspect of this job is to make sure that the original files are not corrupted or changed during the copying and renaming processes. I have previously found that files often fail to copy correctly when copying files from mobile phones to the PC, hence this request for an automated checking process.

I will need a graphical user interface which will take at least the following as inputs.

Source folder = SF
Destination Folder 1 = DF1
Destination Folder 2 = DF2
Camera Number = CN
Title1 = T1

1. Scan all the files in the SF and note their creation dates.

2. Create new folders in DF1 for each unique creation date, format is YYMMDD e.g. 230924. If a folder exists, then do not create it.

3. Under each of the date folders, create a new folder called CN. e.g. 230924/1

4. Copy all the files from SF to the CN folder. If the exact same file already exists in the CN folder, then skip it. Flag this to the user at the end.

5. Check that the quantity, size and dates of the copied files in DF1 is the same as the source files in SF.

6. For all files in DF1, copy them to DF2 (no sub-folders) and prefix each of them with T1_YYMMDD_CN_. If T1 is empty, then just prefix with YYMMDD_CN_

7. Check the quantity, size and dates of the copied files in DF2 against originals in DF1 to make sure they are the same.

8. Any differences or errors should be flagged to the user in the end.

9. Some sort of progress bar should be displayed to show the user how the checking, copying and renaming is going.

Basically, I need a foolproof way of ensuring that the copied files are the same as the originals.

I will need the source code.

Please don't forget to tell me what language you will code the solution in.

Please provide your own quote.
