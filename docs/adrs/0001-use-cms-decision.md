# 1. Do not use a CMS for Developing the Complete Pages

**Date**: 2024-11-25  

## Status

Accepted

## Context

As many of the pages in the Complete application are static copy with checkboxes / date fields, it was speculated that using a CMS to generate these pages would be quicker and allow Content Designers to do the work alongside Developers, as well as allowing for updates without requiring a code release.

## Decision

It was decided that the CMS would not speed up the development of the Complete application and so would not be used.

## Reasons for the Decision

 - Using a CMS creates another technology / skill set for the devs to understand / have experience in
 - Selected CMS may be Open source now, but may not be guaranteed long term
 - A third party CMS would require continual updating and maintenance
 - Changes other than copy changes potentially require more work than if the pages were just static – adding a new control / validation logic may be more involved
 - Even with a CMS, it would still require dev involvement to add new pages or new controls
 - A CMS would require an extra datastore for the page structure
 - The selected CMS had no out-of-the-box support for SSO, extra paid option
 - Hosting costs / containerising of environment could be prohibitive

## Consequences

 - Developers will have to manually develop all of the static copy pages as per the Ruby version

## Trade-offs

 - Potentially increased development time

## Future Considerations

If use of a CMS becomes more widely spread throughout the RSD estate, this decision could be reconsidered.
