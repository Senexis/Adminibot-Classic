# Commands

## Intro to Commands
Commands are the best way for you to operate Adminibot -- directly from the chat! If you ever need to do something, or want to instruct your moderators to do certain things, you can use these if you don't have access to the main program. Also, there are some commands to allow regular users to interact with the bot in a basic way. You may want to advertise the "!commands" command to users whom are new to Twitch and/or are new to Twitch moderation bots, but that's entirely up to you.

If your stream gets too crowded, you may want to silence certain components using commands to keep the chat going in a user-friendly way. You can also use commands to disable access to certain commands for regular users, to prevent spam even further. If you are interested, please have a look at the (pretty extensive) list below and feel free to try these out!

Note: Some commands are conflicting with other chat bots. For example, most commands in the 'Spam Protection' category conflict with Nightbot's commands. We may be adding an option to change each command to any command you want, but that may not be for a while. Also, please note that these user levels, commands, and descriptions are subject to change at any point in time.

## Explanation
In the below tables, you will notice a column called 'Level'. This column indicates the level of access to the bot (the "user level") you need to use a certain command. For example, a user with user level 2 will be able to use more commands than a user with user level 0. You can find a full description of each user level in the table directly below this text.

Level | Description
--- | ---
**0** | Users in this category are the general audience that is chatting in your stream. Users in this category will have access to the most basic commands. Also, they will have access to any custom command that the stream's moderators or streamer have added for user level 0. The default user level.
**1** | Users in this category are the chat's moderators. They have access to some more advanced commands and can silence the bot in case the stream gets too crowded and the bot goes mad. They can also provide the chat with some fun information, like the top 5 users with the most points. They also have the permission to edit commands, should the information given be incorrect, but cannot add new commands or delete them.
**2** | Users in this category are trusted moderators. They have access to a lot of options, should the streamer not be available to configure or update the bot himself. They can change most spam filter options (but not completely disable or enable them), manage the stream's metadata (like the title), manage the regular and subscriber lists, and a lot of other things.
**3** | Users in this category are the streamer and Twitch staff. Among having access to every single command, they change other users' user level to anything they want, disable or enable spam filters completely, clear points from a specific user or all users, and force the bot to leave the chat completely. Whatever they want to do, they can do it.

## Commands List
### General Commands
Level | Command | Description
--- | --- | ---
**0** | `!commands` | Returns all commands the current user is allowed to use.

### Battletag Commands
Level | Command | Description
--- | --- | ---
**0** | `!tag / !btag / !battletag` | Returns your current battle tag.
**1** | `!tag / !btag / !battletag [boolean]` | Changes whether regular users can use the !btag command.
**0** | `!tag / !btag / !battletag [message]` | Change your current battle tag to `message`.
**1** | `!tag / !btag / !battletag [username] [message]` | Changes the battletag of `username` to `message`.
**0** | `!tag / !btag / !battletag remove` | Removes your own battletag.
**1** | `!tag / !btag / !battletag remove [username]` | Removes the battletag of `username`.

### Currency Commands
Level | Command | Description
--- | --- | ---
**0** | `!points / !currency / ![currency]` | Returns the amount of points you have.
**2** | `!points / !currency / ![currency] [boolean]` | Changes whether regular users can use the !currency command.
**1** | `!points / !currency / ![currency] [username]` | Returns the amount of points `username` has.
**2** | `!points / !currency / ![currency] add [username / online / all] [integer]` | Adds `integer` points to `username`, online users, or all users.
**3** | `!points / !currency / ![currency] clear [username / all]` | Clears the amount of points all users or `username` has (sets points to 0).
**2** | `!points / !currency / ![currency] remove [username / online / all] [integer]` | Removes `integer` points from `username`, online users, or all users.
**2** | `!points / !currency / ![currency] set [username / online / all] [integer]` | Sets the points from `username`, online users, or all users to `integer`.
**1** | `!points / !currency / ![currency] top [integer]` | Returns the top `integer` of users with the most points.

### Custom Commands
Level | Command | Description
--- | --- | ---
**2** | `!com / !command add [command] [userlevel] [response]` | Adds command `command` which responds with `response`. Only `userlevel` can use that command.
**2** | `!com / !command delete [command]` | Deletes command `command`.
**1** | `!com / !command edit [command] [userlevel] [response]` | Edits command `command` to respond with `response`. Changes user level to `userlevel`.

### General Management Commands
Level | Command | Description
--- | --- | ---
**2** | `!bot / !adminibot sub add [username]` | Adds `username` to the internal subscribers list.
**2** | `!bot / !adminibot sub remove [username]` | Removes `username` from the internal subscribers list.
**2** | `!bot / !adminibot disable [command] [boolean]` | Disables `command` if `boolean` is set to true, and it enables `command` if `boolean` is false.
**2** | `!bot / !adminibot game [gamename]` | Changes the streams game name metadata to `gamename`.
**2** | `!bot / !adminibot reg add [username]` | Adds `username` to the regular users list, protecting them from all spam filters.
**2** | `!bot / !adminibot reg del [username]` | Removes `username` from the regular users list.
**3** | `!bot / !adminibot leave` | Forces the bot to leave the channel completely. The only way to make him join again is from the program.
**3** | `!bot / !adminibot level set [username] [integer]` | Sets the user level from `username` to `integer`.
**1** | `!bot / !adminibot silence [boolean]` | Changes whether the bot will give ANY response to ALL commands or completely silences the bot.
**2** | `!bot / !adminibot status [title]` | Changes the streams title metadata to `title`.

### Other Commands
Level | Command | Description
--- | --- | ---
**1** | `!so / !shoutout [username]` | Shouts-out Twitch user `username` in the chat including a link.

### Poll Commands
Level | Command | Description
--- | --- | ---
**0** | `!vote / !poll vote [option]` | Adds your vote for `option` to the poll.
**1** | `!poll close` | Closes the poll and displays the poll's results.
**1** | `!poll open [option 1] [option 2] [...] [option 10]` | Resets the poll, creates `option 1` through `option 10` and opens a new poll.
**1** | `!poll reset` | Resets the poll, clearing all votes and set options. 
**1** | `!poll result` | Displays the poll's results but does not close it.

### Raffle Commands
Level | Command | Description
--- | --- | ---
**0** | `!raffle` | Enters your name in the current raffle if it is open.
**1** | `!raffle close` | Closes the raffle and display the winner.
**1** | `!raffle draw` | Display the raffle's results but does not close it.
**1** | `!raffle open` | Resets the raffle - removing all entries -  and opens a new one.
**1** | `!raffle reset` | Resets the raffle, removing all entries.
**1** | `!raffle total` | Displays the number of entries for the current raffle.
**1** | `!raffle userlist [integer]` | Displays [integer] of randomly picked entered usernames.

### Spam Protection
Level | Command | Description
--- | --- | ---
**1** | `!allow / !permit [username]` | Allows `username` to post a (1) link.
**3** | `!capstime [boolean]` | Changes whether the caps timeout spam protection is enabled or disabled.
**2** | `!capstime limit [boolean / integer]` | Changes whether there is a limit to how many caps users may use in a chat message, or sets the limit to `integer`.
**2** | `!capstime msg [boolean / message]` | Changes whether the bot shows a message when a user is timed out for using too many caps or not, or sets the message to `message`.
**1** | `!capstime silence [boolean]` | Changes whether the bot shows any message at all when a user is timed out for using too many caps or not.
**3** | `!emotetime [boolean]` | Changes whether the emoticon timeout spam protection is enabled or disabled.
**2** | `!emotetime limit [boolean / integer]` | Changes whether there is a limit to how many emoticons users may use in a chat message, or sets the limit to `integer`.
**2** | `!emotetime msg [boolean / message]` | Changes whether the bot shows a message when a user is timed out for using too many emoticons or not, or sets the message to `message`.
**1** | `!emotetime silence [boolean]` | Changes whether the bot shows any message at all when a user is timed out for using too many emoticons or not.
**3** | `!linktime [boolean]` | Changes whether the link timeout spam protection is enabled or disabled.
**2** | `!linktime msg [boolean / message]` | Changes whether the bot shows a message when a user is timed out for using a link or not, or sets the message to `message`.
**1** | `!linktime silence [boolean]` | Changes whether the bot shows any message at all when a user is timed out for using a link or not.
**2** | `!linktime whitelist add [link]` | Adds (link) to the whitelist, allowing users to post links including the term used in `link`.
**2** | `!linktime whitelist remove [link]` | Removes (link) from the whitelist, timing out users who use the term used in `link`.
**3** | `!repeatstime [boolean]` | Changes whether the repeated characters timeout spam protection is enabled or disabled.
**2** | `!repeatstime limit letters [boolean / integer]` | Changes whether there is a limit to how many repeated characters users may use in a chat message, or sets the limit to `integer`.
**2** | `!repeatstime limit words [boolean / integer]` | Changes whether there is a limit to how many repeated words users may use in a chat message, or sets the limit to `integer`.
**2** | `!repeatstime msg [boolean / message]` | Changes whether the bot shows a message when a user is timed out for using too repeated characters and words or not, or sets the message to `message`.
**1** | `!repeatstime silence [boolean]` | Changes whether the bot shows any message at all when a user is timed out for using too many repeated characters and words or not.
**3** | `!symboltime [boolean]` | Changes whether the repeated symbols timeout spam protection is enabled or disabled.
**2** | `!symboltime limit [boolean / integer]` | Changes whether there is a limit to how many repeated symbols users may use in a chat message, or sets the limit to `integer`.
**2** | `!symboltime mgs [boolean / message]` | Changes whether the bot shows a message when a user is timed out for using too many repeated symbols or not, or sets the message to `message`.
**1** | `!symboltime silence [boolean]` | Changes whether the bot shows any message at all when a user is timed out for using too many repeated symbols or not.

### Time Watched Commands
Level | Command | Description
--- | --- | ---
**0** | `!time` | Returns the time you have watched the stream.
**1** | `!time [boolean]` | Changes whether regular users can use !time command.
**1** | `!time [username]` | Returns the time `username` has watched the stream.
**1** | `!time top [integer]` | Returns the top `integer` of users who watched the stream the longest.

### Twitch Staff Commands
Level | Command | Description
--- | --- | ---
**3** | `!adminibot leave` | Forces the bot to leave the channel completely. The only way to make him join again is from the program.

### Coming Soon (Maybe)
* Betting commands, allowing users to bet on certain things.
* Auction commands, allowing streamers to auction a certain item for currency.
* Songrequest commands, allowing streamers to play the music the audience wants to hear.

*Subject to change. This file was last updated on the 15th of April 2015.*