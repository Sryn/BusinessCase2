# BusinessCase2
1st Upload - Finished Program

Sun 23 Aug 2015 7pm GMT+8

Business Case 2 h/w - Data Migration C# Program

Dafesty Video Rental, noticed that some of their customer address has not been updated.  A few years back, the Singapore Post revised that postal district from a four digit district code to a six digit code.  the way the code is changed is given below:

Old Code: 18 52

New Code: 52 0 839

The last two digits of the old code becomes the first two digits of the new code.

The last three digits of the new code is the block Number in the address.

If there is an alphabet after the block number e.g. 839B then the third digit would become non-zero with 1 for A, 2 for B and so on.  Fortunately there are no blocks beyond H.

Stored Format for data -
The company has stored all data in a single field.  Fortunately the blocks are indicated with the word Block or Blk and are casually followed by the numeral (block Number).  The Postal Code always succeeds the word Singapore and is always towards the end.

Finished at about 9:30pm GMT+8 Sun 23 Aug 2015
