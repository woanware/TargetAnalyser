# Configuration

This **configuration** document details the XML config files used to configure the inputs and API keys.

## Inputs.xml

The following details the XML for the **Inputs.xml** file, which is located in the application directory.

- **Name**: Name of the input e.g. VirusTotal (MD5)
- **Url**: The URL of the main page for the input e.g. https://www.virustotal.com/vtapi/v2/file/report
- **FullUrl**: The full URL used to retrieve the data from the source. Can include the **#DATA#** marker and also API key markers e.g. 

```
https://www.virustotal.com/vtapi/v2/file/report?resource=#DATA#&amp;apikey=#VT_API_KEY#
```

- **DataTypes**: A list of the supported data types that can be extracted from the input (MD5, IP, Domain, URL)

```
<DataTypes>
    <string>MD5</string>
	<string>IP</string>
</DataTypes>
```

- **Regexes**: A list of regular expressions that are used to extract data from the page retrieved from the FullUrl location. Each regular expression should include a group e.g. \"response_code\":\s(.*?),


```
<Regexes>
	<string>\"response_code\":\s(.*?),</string>
	<string>\"scan_date\":\s"(.*?)",</string>
	<string>\"positives\":\s(.*?),</string>
	<string>\"total\":\s(.*?),</string>
	<string>\"result\":\s"(.*?)",</string>
</Regexes>
```

- **Results**: A list of names/titles/values that relate one to one with the **Regexes** defined

```
<Results>
	<string>Response Code</string>
	<string>Scan Date</string>
	<string>Positives</string>
	<string>Total</string>
	<string>Result</string>
</Results>
```

- **MultipleMatchRegex**: A single regular expression that can identify multiple values from a page. The first result is displayed, and the rest are stored as extended information
- **LinkRegex**: A single regular expression used to extract a URL that provides an easy way to reference back to the page e.g.\"permalink\":\s"(.*?)",
- **HttpMethod**: The HTTP method used for the request (GET, POST)
- **HttpBody**: The HTTP body to be sent. Can include the **#DATA#** marker and also API key markers
- **HttpHeaders**: A list of the HTTP headers to be sent with the request:

```
<HttpHeaders>
	<NameValue>
  		<Name>Content-Type</Name>
  		<Value>application/x-www-form-urlencoded</Value>
	</NameValue>
</HttpHeaders>
```

- **StringNewLines**: This option removes new lines from the HTTP response, with the aim to aid the parsing. Defaults to false

```
<StripNewLines>true</StripNewLines>
```

## API Keys

The following details the XML for the **ApiKeys.xml** file, which is located in the application directory. The API keys file can contain as many API keys as is required.

The application will transpose the matching **Marker** value that is located in the **FullUrl** and/or **HttpBody** properties within the Input.

```
<ApiKeys xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Data>
    <ApiKey>
      <Name>VT</Name>
      <Value>ABC1272djdjdjd</Value>
      <Marker>#VT_API_KEY#</Marker>
    </ApiKey>
    <ApiKey>
      <Name>GSB</Name>
      <Value>ABDBDBre3rewrewrewr</Value>
      <Marker>#GSB_API_KEY#</Marker>
    </ApiKey>
  </Data>
</ApiKeys>
```

