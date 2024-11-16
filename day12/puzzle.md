These instructions would be handled as follows:

- F10 would move the ship 10 units east (because the ship starts by facing east) to east 10, north 0.
- N3 would move the ship 3 units north to east 10, north 3.
- F7 would move the ship another 7 units east (because the ship is still facing east) to east 17, north 3.
- R90 would cause the ship to turn right by 90 degrees and face south; it remains at east 17, north 3.
- F11 would move the ship 11 units south to east 17, south 8.

At the end of these instructions, the ship's Manhattan distance (sum of the absolute values of its east/west position and its north/south position) from its starting position is 17 + 8 = 25.