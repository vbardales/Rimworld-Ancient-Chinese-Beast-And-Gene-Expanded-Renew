# Pickle runs kept as proof

One line per run whose evidence is still on disk in `Tests/Pickle/Evidence/` (out of git). Counts read from each `summary.json`, 2026-11-22. Older runs: `Docs/runs/<date>.md` and the `*-status-history.md` files.

| Evidence folder | Set | Total | Passed | Failed | Skipped | exitReason | What it proves |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 2026-10-15c-ads2 | ads2 | 11 | 11 | 0 | 0 | passed | ADS2 compatibility pass (feature 14) |
| 2026-10-15d-nocturnal | nocturnal | 11 | 11 | 0 | 0 | passed | Nocturnal Animals pass (feature 16) |
| 2026-10-15e-cce | cce | 1 | 1 | 0 | 0 | passed | Chinese Comprehensive Expansion pass (feature 17) |
| 2026-10-18a-siege-en | partial English | 80 | 78 | 0 | 2 | watchdog-timeout | partial English run, tree ecf6758 |
| 2026-11-06b-original-en | incompat-original | 1 | 1 | 0 | 0 | passed | feature 13, original mod, ticket bacf, tree 6589e5f |
| 2026-11-17d-v17-tickbatch | v17tick | 1 | 1 | 0 | 0 | passed | 1.7 drought scenario on the tick-batch step |
| 2026-11-17h-v17-births-2 | v17 | 4 | 4 | 0 | 0 | passed | 1.7 births after a tick batch |
| 2026-11-17i-v17-firecracker | v17 | 1 | 1 | 0 | 0 | passed | 1.7 firecracker chain after a batched watch |
| 2026-11-18a-16-noregression-en | sans-facultatifs | 238 | 200 | 0 | 38 | passed | 1.6 English non-regression proof of 1.2.0 (ticket 1d91) |
