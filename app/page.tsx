import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"
import { QrCode, Share2, Download, Edit, Plus } from "lucide-react"

export default function Home() {
  return (
    <div className="container mx-auto px-4 py-8">
      <header className="mb-8 text-center">
        <h1 className="text-3xl font-bold tracking-tight">Digital Namecard</h1>
        <p className="text-muted-foreground mt-2">Create and share your professional digital business card</p>
      </header>

      <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
        {/* Example namecard */}
        <Card className="overflow-hidden">
          <CardHeader className="bg-primary text-primary-foreground p-6">
            <div className="flex justify-between items-start">
              <div>
                <CardTitle className="text-xl">John Doe</CardTitle>
                <CardDescription className="text-primary-foreground/80 mt-1">Software Developer</CardDescription>
              </div>
              <div className="h-16 w-16 rounded-full bg-white/20 flex items-center justify-center text-xl font-bold">
                JD
              </div>
            </div>
          </CardHeader>
          <CardContent className="p-6">
            <div className="space-y-3">
              <div>
                <p className="text-sm text-muted-foreground">Email</p>
                <p>john.doe@example.com</p>
              </div>
              <div>
                <p className="text-sm text-muted-foreground">Phone</p>
                <p>+1 (555) 123-4567</p>
              </div>
              <div>
                <p className="text-sm text-muted-foreground">Company</p>
                <p>Tech Solutions Inc.</p>
              </div>
            </div>
          </CardContent>
          <CardFooter className="bg-muted/50 p-4 flex justify-between">
            <Button variant="outline" size="sm">
              <QrCode className="h-4 w-4 mr-2" />
              QR Code
            </Button>
            <Button variant="outline" size="sm">
              <Share2 className="h-4 w-4 mr-2" />
              Share
            </Button>
          </CardFooter>
        </Card>

        {/* Create new card */}
        <Card className="flex flex-col items-center justify-center p-6 border-dashed">
          <div className="rounded-full bg-muted w-16 h-16 flex items-center justify-center mb-4">
            <Plus className="h-8 w-8 text-muted-foreground" />
          </div>
          <h3 className="font-medium text-lg mb-2">Create New Card</h3>
          <p className="text-muted-foreground text-center mb-4">Design your professional digital business card</p>
          <Button>Get Started</Button>
        </Card>

        {/* Templates card */}
        <Card>
          <CardHeader>
            <CardTitle>Templates</CardTitle>
            <CardDescription>Choose from our professional templates</CardDescription>
          </CardHeader>
          <CardContent>
            <div className="grid grid-cols-2 gap-2">
              <div className="aspect-[4/3] rounded-md bg-gradient-to-br from-blue-500 to-purple-600"></div>
              <div className="aspect-[4/3] rounded-md bg-gradient-to-br from-amber-500 to-pink-500"></div>
              <div className="aspect-[4/3] rounded-md bg-gradient-to-br from-green-400 to-cyan-500"></div>
              <div className="aspect-[4/3] rounded-md bg-gradient-to-br from-neutral-200 to-neutral-400"></div>
            </div>
          </CardContent>
          <CardFooter>
            <Button variant="outline" className="w-full">
              Browse All Templates
            </Button>
          </CardFooter>
        </Card>
      </div>

      <div className="mt-12">
        <h2 className="text-2xl font-bold mb-6">Features</h2>
        <div className="grid gap-6 md:grid-cols-3">
          <Card>
            <CardHeader>
              <CardTitle className="flex items-center">
                <QrCode className="h-5 w-5 mr-2" />
                QR Code Sharing
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-muted-foreground">
                Generate a QR code for your digital namecard that others can scan to instantly save your contact
                information.
              </p>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <CardTitle className="flex items-center">
                <Download className="h-5 w-5 mr-2" />
                Export Options
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-muted-foreground">
                Export your digital namecard as a PDF, image, or vCard file to share through email or messaging apps.
              </p>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <CardTitle className="flex items-center">
                <Edit className="h-5 w-5 mr-2" />
                Easy Customization
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-muted-foreground">
                Customize your namecard with your brand colors, logo, and choose from multiple layout options.
              </p>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}

