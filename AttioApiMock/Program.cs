using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors();
        builder.Services.AddAuthentication().AddBearerToken();
        builder.Services.AddAuthorization();
        var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();

        var returnData = """
		{
			"data": [
			{
				"id": {
					"workspace_id": "14beef7a-99f7-4534-a87e-70b564330a4c",
					"object_id": "97052eb9-e65e-443f-a297-f2d9a4a7f795",
					"record_id": "bf071e1f-6035-429d-b874-d83ea64ea13b"
				},
				"created_at": "2022-11-21T13:22:49.061281000Z",
				"web_url": "https://app.attio.com/salarya/person/bf071e1f-6035-429d-b874-d83ea64ea13b",
				"values": {
					"strongest_connection_strength_legacy": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": 54.725113205693695,
						"attribute_type": "number"
					}
					],
					"last_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"twitter": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://x.com/johnsmith",
						"attribute_type": "text"
					}
					],
					"avatar_url": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://d1ts43dypk8bqh.cloudfront.net/v1/avatars/b792e7f9-003d-494f-a7b4-a53251c621e6",
						"attribute_type": "text"
					}
					],
					"job_title": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "Software Engineer",
						"attribute_type": "text"
					}
					],
					"next_calendar_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"company": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"target_object": "companies",
						"target_record_id": "f528bd86-8142-4359-9a8c-b651d50a27b1",
						"attribute_type": "record-reference"
					}
					],
					"primary_location": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"line_1": "1 Infinite Loop",
						"line_2": null,
						"line_3": null,
						"line_4": null,
						"locality": "Cupertino",
						"region": "CA",
						"postcode": "95014",
						"country_code": "US",
						"latitude": "37.331741",
						"longitude": "-122.030333",
						"attribute_type": "location"
					}
					],
					"angellist": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://angellist.com/johnsmith",
						"attribute_type": "text"
					}
					],
					"description": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"value": "Developer met at event",
						"attribute_type": "text"
					}
					],
					"strongest_connection_user": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"referenced_actor_type": "workspace-member",
						"referenced_actor_id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64",
						"attribute_type": "actor-reference"
					}
					],
					"strongest_connection_strength": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"option": {
							"id": {
								"workspace_id": "ca10906c-6785-464e-bb6c-b003e63c6a18",
								"object_id": "cf49cf53-dbb4-4d18-87fc-28aba21d7a49",
								"attribute_id": "7914c8c4-34b1-42b6-9e4c-4db8baa58bfa",
								"option_id": "e37175a9-94f3-410f-bb29-78287bc1c444"
							},
							"title": "Very strong",
							"is_archived": false
						},
						"attribute_type": "select"
					}
					],
					"last_email_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "system",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"email_addresses": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"original_email_address": "john-smith@attio.com",
						"email_address": "john-smith@attio.com",
						"email_domain": "attio.com",
						"email_root_domain": "attio.com",
						"email_local_specifier": "john-smith",
						"attribute_type": "email-address"
					}
					],
					"first_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "system",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"created_at": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "2023-01-01T15:00:00.000000000Z",
						"attribute_type": "timestamp"
					}
					],
					"created_by": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"referenced_actor_type": "workspace-member",
						"referenced_actor_id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64",
						"attribute_type": "actor-reference"
					}
					],
					"last_calendar_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"linkedin": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://linkedin.com/in/johnsmith",
						"attribute_type": "text"
					}
					],
					"facebook": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://facebook.com/johnsmith",
						"attribute_type": "text"
					}
					],
					"name": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"first_name": "John",
						"last_name": "Smith",
						"full_name": "John Smith",
						"attribute_type": "personal-name"
					}
					],
					"first_calendar_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"twitter_follower_count": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": 100,
						"attribute_type": "number"
					}
					],
					"instagram": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"value": "https://instagram.com/johnsmith",
						"attribute_type": "text"
					}
					],
					"first_email_interaction": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "system",
							"id": null
						},
						"interaction_type": "email",
						"interacted_at": "2023-01-01T15:00:00.000000000Z",
						"owner_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"attribute_type": "interaction"
					}
					],
					"phone_numbers": [
					{
						"active_from": "2023-01-01T15:00:00.000000000Z",
						"active_until": null,
						"created_by_actor": {
							"type": "workspace-member",
							"id": "a976f6a9-fc2b-4acb-91e7-afb2d18b4e64"
						},
						"country_code": "US",
						"original_phone_number": "+15558675309",
						"phone_number": "+15558675309",
						"attribute_type": "phone-number"
					}
					]
				}
			}
			]
		}
		""";

        app.MapPost("/v2/objects/people/records/query", () => returnData);

        app.Run();
    }
}
