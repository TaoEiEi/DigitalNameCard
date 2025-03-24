import { Button } from "@/components/ui/button"
import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card"
import { Download, Mail, Phone, Globe, MapPin, QrCode, Share2 } from "lucide-react"
import Link from "next/link"

// This would normally come from a database
const mockNamecard = {
  id: "123",
  fullName: "John Doe",
  jobTitle: "Software Developer",
  company: "Tech Solutions Inc.",
  email: "john.doe@example.com",
  phone: "+1 (555) 123-4567",
  website: "https://johndoe.com",
  address: "123 Tech Street, San Francisco, CA",
  bio: "Experienced software developer with a passion for creating elegant solutions to complex problems.",
  socialLinks: [
    { platform: "LinkedIn", url: "https://linkedin.com/in/johndoe" },
    { platform: "Twitter", url: "https://twitter.com/johndoe" },
    { platform: "GitHub", url: "https://github.com/johndoe" },
  ],
}

export default function ViewNamecard({ params }) {
  // In a real app, you would fetch the namecard data based on the ID
  const namecard = mockNamecard

  return (
    <div className="container mx-auto px-4 py-8 max-w-2xl">
      <Card className="overflow-hidden">
        <CardHeader className="bg-primary text-primary-foreground p-8">
          <div className="flex flex-col md:flex-row justify-between items-center gap-6">
            <div className="text-center md:text-left">
              <h1 className="text-3xl font-bold">{namecard.fullName}</h1>
              <p className="text-primary-foreground/80 text-lg mt-1">{namecard.jobTitle}</p>
              <p className="text-primary-foreground/70 mt-1">{namecard.company}</p>
            </div>
            <div className="h-24 w-24 rounded-full bg-white/20 flex items-center justify-center text-3xl font-bold">
              {namecard.fullName
                .split(" ")
                .map((n) => n[0])
                .join("")
                .substring(0, 2)}
            </div>
          </div>
        </CardHeader>

        <CardContent className="p-6 md:p-8">
          {namecard.bio && (
            <div className="mb-6 pb-6 border-b">
              <h2 className="text-lg font-medium mb-2">About</h2>
              <p>{namecard.bio}</p>
            </div>
          )}

          <div className="grid gap-6 md:grid-cols-2">
            <div>
              <h2 className="text-lg font-medium mb-4">Contact Information</h2>
              <div className="space-y-4">
                <div className="flex items-start">
                  <Mail className="h-5 w-5 mr-3 text-muted-foreground mt-0.5" />
                  <div>
                    <p className="text-sm text-muted-foreground">Email</p>
                    <a href={`mailto:${namecard.email}`} className="hover:underline">
                      {namecard.email}
                    </a>
                  </div>
                </div>

                <div className="flex items-start">
                  <Phone className="h-5 w-5 mr-3 text-muted-foreground mt-0.5" />
                  <div>
                    <p className="text-sm text-muted-foreground">Phone</p>
                    <a href={`tel:${namecard.phone}`} className="hover:underline">
                      {namecard.phone}
                    </a>
                  </div>
                </div>

                {namecard.website && (
                  <div className="flex items-start">
                    <Globe className="h-5 w-5 mr-3 text-muted-foreground mt-0.5" />
                    <div>
                      <p className="text-sm text-muted-foreground">Website</p>
                      <a href={namecard.website} target="_blank" rel="noopener noreferrer" className="hover:underline">
                        {namecard.website.replace(/^https?:\/\//, "")}
                      </a>
                    </div>
                  </div>
                )}

                {namecard.address && (
                  <div className="flex items-start">
                    <MapPin className="h-5 w-5 mr-3 text-muted-foreground mt-0.5" />
                    <div>
                      <p className="text-sm text-muted-foreground">Address</p>
                      <p>{namecard.address}</p>
                    </div>
                  </div>
                )}
              </div>
            </div>

            <div>
              <h2 className="text-lg font-medium mb-4">Social Media</h2>
              <div className="space-y-3">
                {namecard.socialLinks.map((link, index) => (
                  <a
                    key={index}
                    href={link.url}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="flex items-center p-3 rounded-md border hover:bg-muted transition-colors"
                  >
                    <div className="h-8 w-8 rounded-full bg-muted flex items-center justify-center mr-3">
                      {link.platform === "LinkedIn" && (
                        <svg className="h-4 w-4" fill="currentColor" viewBox="0 0 24 24">
                          <path d="M20.447 20.452h-3.554v-5.569c0-1.328-.027-3.037-1.852-3.037-1.853 0-2.136 1.445-2.136 2.939v5.667H9.351V9h3.414v1.561h.046c.477-.9 1.637-1.85 3.37-1.85 3.601 0 4.267 2.37 4.267 5.455v6.286zM5.337 7.433c-1.144 0-2.063-.926-2.063-2.065 0-1.138.92-2.063 2.063-2.063 1.14 0 2.064.925 2.064 2.063 0 1.139-.925 2.065-2.064 2.065zm1.782 13.019H3.555V9h3.564v11.452zM22.225 0H1.771C.792 0 0 .774 0 1.729v20.542C0 23.227.792 24 1.771 24h20.451C23.2 24 24 23.227 24 22.271V1.729C24 .774 23.2 0 22.222 0h.003z" />
                        </svg>
                      )}
                      {link.platform === "Twitter" && (
                        <svg className="h-4 w-4" fill="currentColor" viewBox="0 0 24 24">
                          <path d="M23.953 4.57a10 10 0 01-2.825.775 4.958 4.958 0 002.163-2.723c-.951.555-2.005.959-3.127 1.184a4.92 4.92 0 00-8.384 4.482C7.69 8.095 4.067 6.13 1.64 3.162a4.822 4.822 0 00-.666 2.475c0 1.71.87 3.213 2.188 4.096a4.904 4.904 0 01-2.228-.616v.06a4.923 4.923 0 003.946 4.827 4.996 4.996 0 01-2.212.085 4.936 4.936 0 004.604 3.417 9.867 9.867 0 01-6.102 2.105c-.39 0-.779-.023-1.17-.067a13.995 13.995 0 007.557 2.209c9.053 0 13.998-7.496 13.998-13.985 0-.21 0-.42-.015-.63A9.935 9.935 0 0024 4.59z" />
                        </svg>
                      )}
                      {link.platform === "GitHub" && (
                        <svg className="h-4 w-4" fill="currentColor" viewBox="0 0 24 24">
                          <path d="M12 0C5.374 0 0 5.373 0 12c0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576C20.566 21.797 24 17.3 24 12c0-6.627-5.373-12-12-12z" />
                        </svg>
                      )}
                    </div>
                    <span>{link.platform}</span>
                  </a>
                ))}
              </div>
            </div>
          </div>
        </CardContent>

        <CardFooter className="bg-muted/50 p-6 flex flex-wrap gap-3 justify-between">
          <Button variant="outline">
            <QrCode className="h-4 w-4 mr-2" />
            QR Code
          </Button>
          <Button variant="outline">
            <Share2 className="h-4 w-4 mr-2" />
            Share
          </Button>
          <Button variant="outline">
            <Download className="h-4 w-4 mr-2" />
            Save Contact
          </Button>
        </CardFooter>
      </Card>

      <div className="mt-8 text-center">
        <p className="text-muted-foreground mb-4">Create your own digital namecard</p>
        <Link href="/create">
          <Button>Get Started</Button>
        </Link>
      </div>
    </div>
  )
}

