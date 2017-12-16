﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Points : MonoBehaviour {

    /// <summary>
    /// Google API Key
    /// </summary>
    public string apiKey;
    public int tempcounter = 0;
    public int counter = 0;
    public void Generate(int _counter) {
        double x = OnlineMapsLocationService.instance.GetLocationX();
        double y = OnlineMapsLocationService.instance.GetLocationY();
        counter = _counter;
        // Makes a request to Google Places API.
        OnlineMapsGooglePlaces.FindNearby(
            apiKey,
            new OnlineMapsGooglePlaces.NearbyParams(
                x, // Longitude
                y, // Latitude
                500) // Radius
            {
                types = "restaurant"
            }).OnComplete += OnComplete;
    }

    /// <summary>
    /// This method is called when a response is received.
    /// </summary>
    /// <param name="s">Response string</param>
    private void OnComplete(string s) {
        // Trying to get an array of results.
        OnlineMapsGooglePlacesResult[] results = OnlineMapsGooglePlaces.GetResults(s);

        // If there is no result
        if (results == null) {
            Debug.Log("Error");
            Debug.Log(s);
            return;
        }

        List<OnlineMapsMarker> markers = new List<OnlineMapsMarker>();
        foreach (OnlineMapsGooglePlacesResult result in results) {
            if (tempcounter < counter)
            {
                tempcounter++;
                Debug.Log("TEMPCOUNTER " + tempcounter + " AND COUNTER " + counter);
                // Create a marker at the location of the result.
                OnlineMapsMarker marker = OnlineMaps.instance.AddMarker(result.location, result.name);
                markers.Add(marker);
            }
        }
    }
}
