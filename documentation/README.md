# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** Hackathon Category :
Best enhancement to the Sitecore Admin (XP) UI for Content Editors & Marketers

What is the purpose of your module? What problem does it solve and how does it do that?
The main purpose of the module is to help the content editors and marketers to add the Salesforce based personalization to any content item without developement team's effort.

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Salesforce pixel to be installed on the page which helps to inject the cookie for the module to work.

## Installation
Use the Sitecore Installation wizard to install the [package](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/sc.package/Salesforce%20Personalization-v1.0.zip)

## Dataflow

Salesforce exposes a cookie in the browser on a user visit. Salesforce data is always read directly from the cookie by the Sitecore(but doesn’t do a round trip it would read from the http request) and will not store it.
![Data Flow](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/images/1.png)

## Usage

1. Begin editing the page you intend to personalize

2. Select the component and click the personalize icon
![Edit component](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/images/2.png)

3. Personalize the component window will open select New Condition
![Personalize component](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/images/4.png)

4. Select edit and add the Salesforce rule. Find out the cookie key provided by salesforce, key in the key and value 
![Salesforce rules](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/images/5.png)

5. Support for String operations
![String operations](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/images/6.png)

6. Compare the krux_visits or krux_segments much more. Blend the salesforce data and personalize in the Sitecore

## Video

Please check the Video demo in the following link
[Demo Video](https://github.com/Sitecore-Hackathon/2019-Sitecorian/blob/master/documentation/demovideo.zip)
