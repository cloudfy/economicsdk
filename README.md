# E-conomic SDK
SDK to integrate with e-conomic, online provider of ERP. 

## Getting started (before you code)
You can sign up for a FREE demo account to use the API here:
- https://www.e-conomic.dk/regnskabsprogram/demo

To get a development token aka secret token, please visit the following url:
- https://www.e-conomic.com/developer

## Using the SDK
Use the EconomicClient object as the main entry point.

```
EconomicService client = new EconomicService(grantToken, secretToken);
client...

```