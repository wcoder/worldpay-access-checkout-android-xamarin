# Access Checkout Android SDK

![version](http://img.shields.io/badge/original-v1.2.0-brightgreen.svg?style=flat)
[![NuGet Badge](https://buildstats.info/nuget/Xamarin.Droid.Worldpay.Access.Checkout)](https://www.nuget.org/packages/Xamarin.Droid.Worldpay.Access.Checkout/)

Port of [Worldpay/access-checkout-android](https://github.com/Worldpay/access-checkout-android) SDK for Xamarin.Android.

A lightweight library and sample app that generates a Worldpay session reference from payment card data.
It includes, optionally, custom Android views that identifies card brands and validates payment cards and card expiry dates.

<img width="300" alt="app02" src=https://github.com/Worldpay/access-checkout-android/blob/master/images/sample.png>

## Setup

#### NuGet:

```
Install-Package Xamarin.Droid.Worldpay.Access.Checkout
```

## Integration

### Basics

The main step required in order to use the Access Checkout SDK is the initialisation of an instance of `AccessCheckoutClient`. 
Interaction with this class will allow developers to obtain a session state from Access Worldpay services. 

This can be achieved by invoking the `Init()` method of this class and by providing the required dependencies, more details provided in the following sections.

`AccessCheckoutCard` is the coordinator class between the view inputs, the (optional) validators of those inputs, and the callback of those validation results to an implementation of `CardListener`

The SDK is fully customizable and provides default card views that implement the required interfaces out of the box. For advanced styling, it is possible to override some of the default implementations or to provide fully customized implementations of the required interfaces. The interfaces are described at the end of the section.

Firstly, a layout configuration file with the card views is defined as below:

```xml
<com.worldpay.access.checkout.views.PANLayout
    android:id="@+id/panView"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    .../>
<com.worldpay.access.checkout.views.CardExpiryTextLayout
    android:id="@+id/cardExpiryText"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    .../>
<com.worldpay.access.checkout.views.CardCVVText
    android:id="@+id/cardCVVText"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:hint="CVV"
    .../>
```

// TODO

#### Initialisation parameters

- Base API URL: Base URL for Access Worldpay services
- Merchant ID: Your registered Access Worldpay Merchant ID
- SessionResponseListener:  Reference to the listener which will receive the session response (or any service/API errors)
- Context:                  [Android Context](https://developer.android.com/reference/android/content/Context)
- LifecycleOwner:           [Android LifecycleOwner](https://developer.android.com/reference/android/arch/lifecycle/LifecycleOwner)

### Validation

In order to take advantage of the in-built validation on the card fields, there are additional setup steps.


// TODO

#### Receiving the Session State 

When the request for a session state starts, the `ISessionResponseListener` is notified via the  `OnRequestStarted()` callback method. 

When a result becomes available, the implementing class of `ISessionResponseListener` will receive the callback holding the session state or an exception describing the error.

`OnRequestFinished(srting sessionState, AccessCheckoutException error)`

#### When things go wrong: `AccessCheckoutException`

If there is a problem, `ISessionResponseListener` will be notified through the same `OnRequestFinished(srting sessionState, AccessCheckoutException error)` callback, this time with a `null` sessionState and non-null error.


// TODO

