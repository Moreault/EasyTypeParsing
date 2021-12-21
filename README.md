![autoinject](https://github.com/Moreault/EasyTypeParsing/blob/master/easytypeparsing.png)

# EasyTypeParsing
Extension methods to make it easier to parse strings into other types.

```c#
public void DoSomeShadyStuff(string aNumberMaybe, string definitelyANumber, string iDontCareIfItsANumber)
{
  //A number... maybe? Let's try to parse it into an integer without throwing exceptions
  var number = aNumberMaybe.ToInt();
  
  if (number.IsSuccess)
  {
    //It worked! This is a number!
  }
  else
  {
    //It wasn't a number after all :(
  }
  
  //If it's definitely a number then we don't have to use white gloves with this one! Convert it or throw in a very savage manner!
  var otherNumber = definitelyANumber.ToIntOrThrow();
  
  //This one could be garbage or a number... but I'm okay with getting a big fat zero in case it failed
  var meh = iDontCareIfItsANumber.ToIntOrDefault();
}
```

I can hear you say "It's all well and good but what if I want to parse Dates?!"

```c#
public void DoMoreShadyStuff(string disguisedDate)
{
  var myDate = disguisedDate.ToDateTimeOrThrow();
}
```

There are methods for most common primitive and not-so-primitive types. 

```c#
//You can also do the following if you don't know the type ahead of time
public void IntensifyShadyness<T>(string ummWhatIsThis)
{
  var thingy = ummWhatIsThis.Parse<T>();
  
  var definiteThingy = ummWhatIsThis.ParseOrThrow<T>();
  
  var recklessThingy = ummWhatIsThis.ParseOrDefault<T>();
}
```
