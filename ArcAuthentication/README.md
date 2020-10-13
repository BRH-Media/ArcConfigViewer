# Arcadyan LH1000 Communication Library
### *For the Telstra Smart Modem Gen 2*

#### Project Outline
Welcome and thankyou for choosing to use BRH Media software!
This is a component of ongoing efforts to reverse engineer the Arcadyan LH1000 for the consumer's preferred use;
including extracting data and interpreting undocumented modem protocols.
There are three main topics we'll go over in this guide, but please first note that we have provided small additional outlines in each folder as necessary. 
The topics covered will be:
- How Arcadyan has implemented authentication and verification
- How we have addressed common road-blocks
- And finally, how you can implement/extend this project into your own workflow.

#### Arcadyan's Authentication Protocol
When you first load the modem's login page, there are two crucial things to note:
- A 'httoken' is generated and encoded as base64
- The modem knows that this token is the only one that should authenticate in that particular session

Hence, after noting this, we can document the authentication process as a numbered list like so:
1. Login page is loaded with a base64 token hidden after character position 78 in the 'spacer' <div>
2. When the user enters his/her details, the page utilises MD5+SHA512 to 'secure' their details; these are called
'usr' and 'pws' in the form data, and the hashing function may be defined as `string SHA512(MD5(string input))`.
3. After submitting the form, it creates a new iframe that is presumably used for checking XSS, etc. However, it's not necessary if we submit directly to the CGI pages.
4. When the modem has hashed the user's details, it includes the 'httoken' it tried to hide in the HTML, hence we will get form data that looks similar to this JSON:<br />
```json
{
  "httoken": "123456789012",
  "usr": "edbd881f1ee2f76ba0bd70fd184f87711be991a0401fd07ccd4b199665f00761afc91731d8d8ba6cbb188b2ed5bfb465b9f3d30231eb0430b9f90fe91d136648",
  "pws": "e9eacf8f740713adc6c8bd4466c19afb074e8a55ebfd7009b96d2bc7f8c32cbea4df176c08692f27ffa7be85b04736a4a32a1c5280113fc996f26f900905353a"
}
```
...For the default credentials 'admin' (usr) and 'Telstra' (pws). It then POSTs this payload to `/login.cgi`, and provides a `Location: /home.htm` header to redirect the user.

5. After the modem has authenticated the user, each new HTML page will be provided an embedded 'httoken' to be submitted on each call to a CGI page; regardless of what it is.
The modem will also store the user Agent of the authenticated user, and thus, we may provide a unique string to ensure we cannot authenticate via browsers when logged in via thi library,
e.g. `User-Agent: ArcConfigViewer/1.0`.

Thus, this concludes the authentication sequence. We now have one more piece of crucial information: on each 'authenticated' request (that is, we have logged in via login.cgi),
we **must** include the httoken of the relevant HTML page; this means we cannot execute certain *.cgi scripts if we are on a certain *.htm page. How do we avoid this? Well,
simply download a copy of the respective HTM page, extract its token, and then execute the *.cgi page with that token; the modem will be none-the-wiser.

#### Some issues we faced whilst developing this solution
1. Every single piece of data sent via the modem (even JSON data) is sent a JavaScript file (*.js). Sometimes, data is even generated upon requesting these scripts too; as is
the case when downloading the encrypted config file bytes from the modem, since one must execute three queries to get the final result.
  - *How did we solve it?* Through the black magic of Regular Expressions (RegEx) of course! Simply download the script, and filter out the data we want.
2. The modem will keep you logged in not via a session cookie, but instead, simply recording your `User-Agent` string and noting your next request; it will determine then
if you may request that resource.
  - *How did we slve it?* By simply requesting `login.htm` and noting the `Location` header and its contents; if it included `/home.htm`, we're logged in, otherwise check
  other details to ensure our authentication status. By doing this, we can inform the program on our authentication status, and hence, we will know when we need to request
  a new 'session' from `/login.cgi`. This process can be easily observed when the `Testing authentication...` loading bar appears.

#### Implementation guide
*Executing an authentication request*

```csharp
  using ArcAuthentication.Security;
  using ArcAuthentication.Net;
  
  public static class Program {
    public static void Main(string[] args) {
      Console.WriteLine(@"Default credentials are being applied");
      
      //The 'hash' flag determines whether to apply the 'ArcMd5' function.
      //This is, of course, true by default. Disable only if you wish to store in plain-text
      //and hash later.
      var auth = new ArcCredential(@"admin", @"Telstra");
      
      //Execute the request to '/login.cgi' and automate the 'httoken' extraction.
      var authSuccess = ArcLogin.DoLogin(auth);
      
      //authSuccess is a boolean, and determines, as the name implies,
      //whether or not the modem accepted your request as legitimate.
      Console.WriteLine(authSuccess
        ? @"Authentication was successful"
        : @"Authentication failed");
    }
  }
```

*Executing a request for information (after you have authenticated)*
```csharp
  
```
