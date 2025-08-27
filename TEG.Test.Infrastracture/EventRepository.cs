using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TEG.Test.Domain.Interface;
using TEG.Test.Domain.Models;

namespace TEG.Test.Infrastracture
{

	public class EventRepository : IEventRepository
	{
		private readonly HttpClient _httpClient;
		private readonly string _eventApiUrl =
			"https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json";
		private readonly string _localFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "event-data.json");

		private EventData? _eventData; // In-memory cache

		public EventRepository(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		/// Ensures event data is loaded in memory.
		/// Attempts API first; falls back to local file if API fails.
		/// </summary>
		private async Task EnsureDataLoadedAsync()
		{
			if (_eventData != null)
				return; // already loaded

			bool loadedFromApi = false;

			// Try fetching from API
			try
			{
				var response = await _httpClient.GetAsync(_eventApiUrl);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					_eventData = JsonSerializer.Deserialize<EventData>(json, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});

					if (_eventData != null)
					{
						// Save locally as fallback
						await File.WriteAllTextAsync(_localFilePath, json);
						loadedFromApi = true;
					}
				}
			}
			catch
			{
				// Ignore API exception; fallback to local
			}

			// Fallback to local file if API failed
			if (!loadedFromApi)
			{
				if (File.Exists(_localFilePath))
				{
					var localJson = await File.ReadAllTextAsync(_localFilePath);
					_eventData = JsonSerializer.Deserialize<EventData>(localJson, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
				}
				else
				{
					throw new Exception("Unable to load event data from API or local file.");
				}
			}
		}

		/// <summary>
		/// Returns all events and venues from memory (loaded from API or local file).
		/// </summary>
		public async Task<EventData?> GetEventsAndVenuesAsync()
		{
			await EnsureDataLoadedAsync();
			return _eventData;
		}
	}
}
