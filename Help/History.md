# TargetAnalyser #

## History ##

**v0.0.10**

- Modified so that the IP void checks display a generic not found message if the IP cannot be identified
- Updated alienvault URL

**v0.0.9**

- Added the ability to make UrlVoid/IpVoid checks passive. Thanks MattN
- Modified the UrlVoid processing to remove "www" sub domains as UrlVoid doesn't recognise them as the main domain. Thanks MattN

**v0.0.8**

- Added a 10s pause on the Virus Total checks when using an import file
- Fixed bug where the CSV export didn’t do anything. Thanks MartinW

**v0.0.7**

- Added the ability to perform a scan from an import file so that lists of IPs, domains or hashes can be performed
- Modified so that the system web proxy is used when performing requests. Thanks DanO

**v0.0.6**

- Added Google Diagnostics as an IP/domain provider
- Modifed the robtek processing to stop duplicates
- Added the Parent URL and URL columns to the results list view

**v0.0.5**

- Updated the robtex regex as they have modified the HTML
- Added a spoof User-Agent since the Hurricane Electric queries were not working correctly

**v0.0.4**

- Modified to allow user selection of sources/providers
- Modified to persist user settings
- Modified to allow command line running
- Improved code layout
- Added ability to export to CSV, XML and JSON

**v0.0.3**

- Added status updates
- Added HpHosts
- Added Hurricane Electric

**v0.0.2**

- Added threadexpert MD5 lookup
- Added VxVault MD5 lookup
- Added MinotaurAnalysis MD5 lookup
- Added VirusTotal MD5 lookup
- Added BKN passive DNS lookup
- Added VirusTotal passive DNS lookup
- Added retry capability

**v0.0.1**

- Initial release

