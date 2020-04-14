## Paranoia-Site-Generator

A C# program to create a static site by extracting data from a MySQL database of the "PARANOIA-Live" forums. "PARANOIA-Live" was a fansite for the science-fiction tabletop RPG 'PARANOIA' that was very popular in the 2000's and early 2010's.

### Info On The Database
The PARANOIA-Live forum is based on a modded version of phpbb (modded to allow the existence of a 'forum game' where players pretend to be average citizens in Alpha Complex, the setting of the PARANOIA RPG).

Therefore, the database essentially uses the same standard tables as the "phpbb forum" schema, with some additional custom tables as well to help support the 'forum game'. If you want details about the standard phpbb schema, please visit [phpbb wiki's article about Tables](https://wiki.phpbb.com/Tables) or [phpbbDoctor's Tables article](http://www.phpbbdoctor.com/doc_columns.php?id=21).

The forums has a long and storied history, but it soon died out in the early 2010's. A backup of the forums was recovered, but only stored post data from its foundation on Thursday, June 19, 2003 (GMT) to Friday, January 20, 2006 (GMT), so forum posts after that date are considered lost and unrecoverable.

In addition, the backup we have was terminated halfway, meaning many standard tables are missing - the most important of the missing tables are:

- phpbb_topics
- phpbb_smilies
- phpbb_users
- phpbb_words (for implementing censorship)

## Learning What Content Is Avaliable And What Was Lost
The XP-era rulebook was released in 2003, and 25th Anniversary edition was released in 2009. The database backup's last post was in 2006, after several XP supplements were released, but before the announcement of 25th Anniversary Edition.

Mandatory Community Mission #1 (VEG Sector) was recently finished and there were still plans to launch MCM #2 (a mission about Funball).

The forum game was still in its golden age, and held two mega-events (Funball and Circus). After 2006 though, activity begin to die out, for both the site and the forum game (the forum game, in particular, required an unsustainable amount of GM activity, which can lead to burnout), eventually causing the forum game to go through a reboot of sorts: five different 'mini-game' Episodes followed by the release of a smaller-scope 'forum game'.

Forums' activity did appear to peter out after 2006 (even the release of 25th Anniversary Edition was not enough to bring activity back), but the site did survive long enough to discuss the 2014 Kickstarter for PARANOIA Red-Clearance Edition (with some discussion being made over whether it was a good idea to change Alpha Complex's enemy from Communists to Terrorists).