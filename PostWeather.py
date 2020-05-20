import requests
import urllib3
import json
urllib3.disable_warnings()

# Get weather data
weather = requests.get("https://api.openweathermap.org/data/2.5/weather?id=STATIONID&appid=APIKEYHERE")
data = weather.json()

if (weather.status_code == 200):
    # Create header for post
    headers = {'Content-Type': 'application/json'}

    # Create the sections for the body
    body = {}
    reading = {}
    temperature = {}
    wind = {}
    humidity = {}
    pressure = {}
    condition = {}

    # Reading section of the body
    reading['reading_Timestamp'] = data['dt']

    # Temperature section of the body
    temperature['temperature'] = data['main']['temp']
    temperature['feels_like'] = data['main']['feels_like']
    temperature['temp_min'] = data['main']['temp_min']
    temperature['temp_max'] = data['main']['temp_max']

    # Wind section of the body
    wind['wind_Speed'] = data['wind']['speed']
    wind['wind_Direction'] = data['wind']['deg']

    # Humidity section of the body
    humidity['humidity'] = data['main']['humidity']

    # Pressure section of the body
    pressure['pressure'] = data['main']['pressure']

    # Condition section of the body
    condition['weather_condition'] =  data['weather'][0]['main']
    condition['condition_description'] = data['weather'][0]['description']
    condition['icon'] = data['weather'][0]['icon']

    # Build the body
    body['reading'] = reading
    body['temperature'] = temperature
    body['wind'] = wind
    body['humidity'] = humidity
    body['pressure'] = pressure
    body['condition'] = condition
    
    # Post to the local weather API
    response = requests.post('https://LOCATIONOFAPI/api/weatherreport', headers=headers, json=body, verify=False)

    if (response.status_code == 200):
        print("Weather Saved to Database")
    else :
        print("Something went wrong saving to the database")

else :
    print("Something went wrong getting weather data from the API")