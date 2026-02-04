namespace Vendors.Api;

public static class StaticVendorList
{
    public static readonly List<Vendor> Vendors = new()
    {
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0001"), "Microsoft", "https://www.microsoft.com", new VendorContact("Alice Johnson", "alice.johnson@microsoft.example", "+1-425-555-0101")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0002"), "Google", "https://www.google.com", new VendorContact("Ravi Patel", "ravi.patel@google.example", "+1-650-555-0102")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0003"), "Amazon Web Services", "https://aws.amazon.com", new VendorContact("Monica Reyes", "monica.reyes@aws.example", "+1-206-555-0103")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0004"), "IBM", "https://www.ibm.com", new VendorContact("David Lee", "david.lee@ibm.example", "+1-914-555-0104")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0005"), "Oracle", "https://www.oracle.com", new VendorContact("Samantha Green", "samantha.green@oracle.example", "+1-650-555-0105")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0006"), "Salesforce", "https://www.salesforce.com", new VendorContact("Carlos Martinez", "carlos.martinez@salesforce.example", "+1-415-555-0106")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0007"), "Atlassian", "https://www.atlassian.com", new VendorContact("Emily Chen", "emily.chen@atlassian.example", "+1-800-555-0107")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0008"), "GitHub", "https://github.com", new VendorContact("Liam O'Connor", "liam.oconnor@github.example", "+1-415-555-0108")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0009"), "GitLab", "https://about.gitlab.com", new VendorContact("Zara Khan", "zara.khan@gitlab.example", "+1-415-555-0109")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0010"), "Docker", "https://www.docker.com", new VendorContact("Tom Baker", "tom.baker@docker.example", null)),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0011"), "Red Hat", "https://www.redhat.com", new VendorContact("Priya Nair", "priya.nair@redhat.example", "+1-617-555-0111")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0012"), "SAP", "https://www.sap.com", new VendorContact("Oliver Brown", "oliver.brown@sap.example", "+49-89-555-0112")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0013"), "VMware", "https://www.vmware.com", new VendorContact("Hannah Wilson", "hannah.wilson@vmware.example", "+1-650-555-0113")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0014"), "Elastic", "https://www.elastic.co", new VendorContact("Mateo Alvarez", "mateo.alvarez@elastic.example", "+1-512-555-0114")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0015"), "MongoDB", "https://www.mongodb.com", new VendorContact("Yuki Tanaka", "yuki.tanaka@mongodb.example", "+1-646-555-0115")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0016"), "Datadog", "https://www.datadoghq.com", new VendorContact("Noah Wright", "noah.wright@datadog.example", null)),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0017"), "Splunk", "https://www.splunk.com", new VendorContact("Aisha Mohammed", "aisha.mohammed@splunk.example", "+1-415-555-0117")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0018"), "HashiCorp", "https://www.hashicorp.com", new VendorContact("Ethan Park", "ethan.park@hashicorp.example", "+1-415-555-0118")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0019"), "Twilio", "https://www.twilio.com", new VendorContact("Nina Rossi", "nina.rossi@twilio.example", "+1-415-555-0119")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0020"), "Stripe", "https://stripe.com", new VendorContact("Jordan King", "jordan.king@stripe.example", null)),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0021"), "Slack", "https://slack.com", new VendorContact("Maya Singh", "maya.singh@slack.example", "+1-415-555-0121")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0022"), "Segment (Twilio)", "https://segment.com", new VendorContact("Victor Hugo", "victor.hugo@segment.example", "+1-415-555-0122")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0023"), "New Relic", "https://newrelic.com", new VendorContact("Sofia Petrova", "sofia.petrova@newrelic.example", "+1-650-555-0123")),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0024"), "Figma", "https://www.figma.com", new VendorContact("Connor Blake", "connor.blake@figma.example", null)),
        new Vendor(Guid.Parse("b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0025"), "JetBrains", "https://www.jetbrains.com", new VendorContact("Irina Kozlova", "irina.kozlova@jetbrains.example", "+1-415-555-0125")),
    };
}

public record Vendor(Guid Id, string Name, string WebSiteUrl, VendorContact Contact);

public record VendorContact(string Name, string Email, string? PhoneNumber);

