## Overview
The scoreboard supports the following operations:
1. Start a new match, assuming initial score 0 – 0 and adding it the scoreboard.
This should capture following parameters:
a. Home team
b. Away team
2. Update score. This should receive a pair of absolute scores: home team score and away
team score.
3. Finish match currently in progress. This removes a match from the scoreboard.
4. Get a summary of matches in progress ordered by their total score. The matches with the
same total score will be returned ordered by the most recently started match in the
scoreboard.

## Key assumptions
- No persitance, in memory list representing the matches
- No summary visual representation since it's a liblary project

## Future ideas
- Persistance, DB connection to store collection of matches
- CQRS, all the operations should be happeing in handlers instead of `ScoreboardService`
- Rest API, to let the user manipulate data and retreive it
- Clean architecture, to seprate layers
- Business exceptions and logging, easier to track what went wrong 
