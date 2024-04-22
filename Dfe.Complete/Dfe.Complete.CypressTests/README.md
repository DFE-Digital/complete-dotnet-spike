## Cypress Testing

### Test Setup

The Cypress tests are designed to run against the front-end of the application. To set up the tests, you need to provide a configuration file named `cypress.env.json` with the following information:

```javascript
{
    "url": "<enter frontend URL>",
    "username": "<enter the user you want to run the tests with>",
    "api": "<enter backend URL>",
    "apiKey": "<enter API key for backend>",
    "authKey": "<enter key set for the CypressTestSecret>"
}
```

While it is possible to pass these configurations through commands, it is easier to store them in the configuration file.

#### Authentication

The authentication is invoked in every test using the `login` command:

```javascript
beforeEach(() => {
    cy.login();
});
```

Intercepts all browser requests and adds a special auth header using the `authKey`. Make sure you set the `CypressTestSecret` in your app, and it matches the `authKey` in the `cypress.env.json` file.

### Test Execution

If you have a `cypress.env.json` file, the `cy:open` and `cy:run` commands will automatically pick up the configuration.

Navigate to the `Dfe.ManageFreeSchoolProjects.CypressTests` directory:

```
cd Dfe.ManageFreeSchoolProjects.CypressTests/
```

To open the Cypress Test Runner, run the following command:

```
npm run cy:open
```

To execute the tests in headless mode, use the following command (the output will log to the console):

```
npm run cy:run
```

### Test linting

We have set up [eslint](https://eslint.org) and [prettier](https://prettier.io/) on the Cypress tests to encourage code quality. This can be run by using the script `npm run lint`

-   Prettier will format all code files
-   Eslint checks will run

All the default rules have been setup

### Security testing with ZAP

The Cypress tests can also be run, proxied via [OWASP ZAP](https://zaproxy.org) for passive security scanning of the application.

These can be run using the configured `docker-compose.yml`, which will spin up containers for the ZAP daemon and the Cypress tests, including all networking required. You will need to update any config in the file before running

Create a `.env` file for docker, this file needs to include

-   all of your required cypress configuration
-   HTTP_PROXY e.g. http://zap:8080
-   ZAP_API_KEY, can be any random guid

Example env:

```
URL=<Enter URL>
USERNAME=<Enter username>
API=<Enter API>
API_KEY=<Enter API key>
AUTH_KEY=<Enter auth key>
HTTP_PROXY=http://zap:8080
ZAP_API_KEY=<Enter random guid>

```

**Note**: You might have trouble running this locally because of docker thinking localhost is the container and not your machine

To run docker compose use:

`docker-compose -f docker-compose.yml --exit-code-from cypress`

**Note**: `--exit-code-from cypress` tells the container to quit when cypress finishes

You can also exclude URLs from being intercepted by using the NO_PROXY setting

e.g. NO_PROXY=google.com,yahoo.co.uk

Alternatively, you can run the Cypress tests against an existing ZAP proxy by setting the environment configuration

```
HTTP_PROXY="<zap-daemon-url>"
NO_PROXY="<list-of-urls-to-ignore>"
```

and setting the runtime variables

`zapReport=true,zapApiKey=<zap-api-key>,zapUrl="<zap-daemon-url>"`

### Accessibility Testing

The `executeAccessibilityTests` command is implemented in Cypress and is used to perform accessibility tests on a web application. It utilises the Axe accessibility testing library to check for accessibility issues based on the specified criteria.

#### Usage

To use this command, simply call `executeAccessibilityTests()` in your Cypress test code. Here's an example:

```javascript
it("should perform accessibility tests", () => {
    // Perform actions and assertions on your web application
    // ...

    // Execute accessibility tests
    cy.executeAccessibilityTests();

    // Continue with other test logic
    // ...
});
```

#### Command Details

The `executeAccessibilityTests` command under "support/commands.ts"

This will run all accessibility rules provided by the framework
