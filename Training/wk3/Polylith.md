In REST, we have constraints...

- We will have a client-server pattern - we have a separation of concerns which allows to reuse services across platforms or across applications. Therefore we can evolve each of the services independently from one another.
- Restful service must be stateless - the service doesn't store a session in application memory. Start clean for
  every request. The client provides any data necessary.
- Cache - mark som eresources as cacheable for them to be stored on the client side
- Uniform interface between the client and the server/service, so the instruction is not tied to implementation. Needed to achieve loose coupling.
  - Identification of resources - version control
  - Manipulating resources through representations - anything done is done through a representation of a state of a resource (HTML, JSON, XML, JPG)
  - Self-descriptive messages
  - Hypermedia as the engine of application state (HATEOAS) - when we use another resource available on a network, the resource will determine what our application does.
- Layered system - servers/services can be clients to other servers. Each one only knows what it is directly connected to.
- Code on demand - a RESTFUL service can download or leverage code for a new feature (Pretty common in browsers).

LEVEL 1 of RESTFUL - identifies resources as URLs
LEVEL 2 of RESTFUL - use HTTP symatically and implement status codes
LEVEL 3 of RESTFUL - make use of hypermedia

What is HTTP? (Hyper Text Transfer Protocol)

- Protocol - set of rules for communication
- HTTP message structure:
  - Head (startline, some headers(optional))
  - Send a empty line
  - Body of our request (optional)

HTTP Request

- start-line: HTTP method (HTTP verbs), request URI (User Requested Information), HTTP version #

HTTP Response

- start-line: HTTP version #, HTTP Status code, Status text
- HTTP status code:
  - 1XX : informational
    - 100 continue: you sent the headers, ok, now send the body
  - 2XX : successful responses
  - 3XX : redirection
  - 4XX : errors from the client side
  - 5XX : errors from the server side

* Some headers are only for requests
* Some headers are only for responses
* Some headers are for both requests and responses
* Some headers for requests, responses, and to describe the body when there is one

## HTTP Request Header

(HTTP Method/Verb) (URI)(HTTP Version)

GET https://www.google.com HTTP/1.1

### Request Headers

(parameter) : (value)
Host: http://www.google.com
Accept: image/gif, image/jpeg
Accept-Language: en-us
User-Agent: Mozilla/4.0
Content-Length: 35

## Blank Line

## HTTP Request Body

## HTTP Message Body

bookId=1234&author=Tan+Ah+Teck

////////////////////////////////////////////////////////
GET https://www.google.com HTTP/1.1
Host: http://www.google.com
Accept: image/gif, image/jpeg
Accept-Language: en-us
User-Agent: Mozilla/4.0
Content-Length: 35

bookId=1234&author=Tan+Ah+Teck

### HTTP Methods (verbs)

GET - Retrieve a resource
*POST - Submitting an entity to a specific resource
*PUT - Replaces the entity at the specified resource with the payload
PATCH - Updating a portion of an entity " " with the payload
DELETE - Deletes the specified entity
HEAD - retrieves the header that we could expect from a GET
OPTIONS

Safe + Idempotent

- A method is safe if it does not change anything on the server(i.e. Read-Only): GET, HEAD, OPTIONS; Not Safe: DELETE
- A method is idempotent if it can be made several times with the same effect and leave the server in the same state
