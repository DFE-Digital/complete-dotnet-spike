// ***********************************************************
// This example support/index.js is processed and
// loaded automatically before your test files.
//
// This is a great place to put global configuration and
// behavior that modifies Cypress.
//
// You can change the location of this file or turn off
// automatically serving support files with the
// 'supportFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/configuration
// ***********************************************************

// Import commands.js using ES2015 syntax:
import { AuthenticationInterceptorParams } from "cypress/auth/authenticationInterceptor";
import "./commands";
import { RuleObject } from "axe-core";

declare global {
    namespace Cypress {
        interface Chainable {
            getByTestId(id: string): Chainable<Element>;
            containsByTestId(id: string): Chainable<Element>;
            getById(id: string): Chainable<Element>;
            containsById(id: string): Chainable<Element>;
            getByClass(className: string): Chainable<Element>;
            getByName(name: string): Chainable<Element>;
            getByRole(role: string): Chainable<Element>;
            getByLabelFor(labelFor: string): Chainable<Element>;
            getByRadioOption(radioText: string): Chainable<Element>;
            login(params?: AuthenticationInterceptorParams): Chainable<Element>;
            loginWithCredentials(): Chainable<Element>;
            loginRuby(): Chainable<Element>;
            assertChildList(selector: string, values: string[]): Chainable<Element>;
            executeAccessibilityTests(ruleExclusions?: RuleObject): Chainable<Element>;
            enterDate(idPrefix: string, day: string, month: string, year: string): Chainable<Element>;
            hasAddress(id: string, line1: string, line2: string, line3: string): Chainable<Element>;
            typeFast(text: string): Chainable<Element>;
            typeText(element: Chainable<Element>, text: string): Chainable<Element>;
        }
    }
}
