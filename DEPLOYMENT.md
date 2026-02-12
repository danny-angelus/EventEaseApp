# EventEase - Deployment Guide

## GitHub Pages Deployment

This document provides step-by-step instructions for deploying EventEase to GitHub Pages.

### Prerequisites

- GitHub account
- Git installed on your computer
- EventEase project completed

### Step 1: Prepare the Repository

1. **Create a new GitHub repository**:
   - Go to [GitHub](https://github.com)
   - Click "New repository"
   - Name it `EventEaseApp`
   - Make it Public
   - Do NOT initialize with README, .gitignore, or license

2. **Initialize Git in your local project** (if not already done):

   ```bash
   cd c:\Users\Syste\OneDrive\Escritorio\Blazor\EventEaseApp
   git init
   git add .
   git commit -m "Initial commit - EventEase app"
   ```

3. **Link to GitHub repository**:
   ```bash
   git remote add origin https://github.com/YOUR_USERNAME/EventEaseApp.git
   git branch -M main
   git push -u origin main
   ```

### Step 2: Configure GitHub Pages

1. **Go to repository Settings**:
   - Navigate to your repository on GitHub
   - Click "Settings" tab
   - Click "Pages" in the left sidebar

2. **Configure Source**:
   - Under "Build and deployment"
   - Source: Select "GitHub Actions"

### Step 3: GitHub Actions Workflow

The workflow file is already created at `.github/workflows/github-pages.yml`. This workflow will:

- ✅ Build the Blazor WebAssembly app
- ✅ Publish it in Release mode
- ✅ Update the base href for GitHub Pages
- ✅ Deploy to GitHub Pages

### Step 4: Trigger Deployment

1. **Push changes** (if you made any):

   ```bash
   git add .
   git commit -m "Add deployment configuration"
   git push
   ```

2. **Monitor deployment**:
   - Go to "Actions" tab on GitHub
   - Watch the workflow run
   - Wait for green checkmark (✓)

3. **Access your app**:
   - URL: `https://YOUR_USERNAME.github.io/EventEaseApp/`
   - It may take 1-2 minutes after deployment completes

### Step 5: Verify Deployment

Visit your deployed app and test:

- ✅ Home page loads correctly
- ✅ Events page shows event list
- ✅ Login functionality works
- ✅ Event registration works
- ✅ User profile displays correctly
- ✅ Attendance tracker shows data
- ✅ All styles load properly

### Troubleshooting

**Issue: 404 Page Not Found**

- Check that base href was updated correctly in index.html
- Ensure GitHub Pages source is set to "GitHub Actions"

**Issue: Blank page**

- Open browser console (F12)
- Check for errors
- Verify .nojekyll file was added

**Issue: Styles not loading**

- Check base href in index.html
- Verify all CSS files are published

**Issue: LocalStorage not working**

- localStorage works in GitHub Pages
- Clear browser cache and try again

### Configuration Details

**Base URL**: The app is configured to run at `/EventEaseApp/`

**Changing the base URL**:

1. Edit `.github/workflows/github-pages.yml`
2. Update line: `sed -i 's/<base href="\/" \/>/<base href="\/YOUR_REPO_NAME\/" \/>/g'`
3. Commit and push

### Manual Deployment (Alternative)

If you prefer to deploy manually:

1. **Build the project**:

   ```bash
   dotnet publish -c Release -o dist
   ```

2. **Update index.html**:
   - Open `dist/wwwroot/index.html`
   - Change `<base href="/" />` to `<base href="/EventEaseApp/" />`

3. **Deploy to GitHub Pages**:
   - Go to repository Settings > Pages
   - Source: Deploy from a branch
   - Branch: Select `gh-pages`
   - Copy contents of `dist/wwwroot/` to `gh-pages` branch

### Production Checklist

Before deploying to production:

- [ ] All features tested locally
- [ ] No console errors
- [ ] All validation working
- [ ] Responsive design tested
- [ ] Performance optimized
- [ ] Code reviewed
- [ ] Documentation updated
- [ ] .nojekyll file included
- [ ] Base href updated correctly

### Updating the App

To update your deployed app:

1. Make changes to your code
2. Commit changes:
   ```bash
   git add .
   git commit -m "Description of changes"
   git push
   ```
3. GitHub Actions will automatically rebuild and redeploy

### Performance Optimization

For production deployment:

1. **Enable compression** (automatic with GitHub Pages)
2. **Lazy loading** - Already implemented with Blazor
3. **CDN** - GitHub Pages uses CDN automatically
4. **Caching** - Configured in workflow

### Security Considerations

- ✅ No sensitive data in client-side code
- ✅ Form validation on client
- ✅ Session data in localStorage (user-specific)
- ✅ No backend API keys exposed

### Support

For issues:

- Check [GitHub Pages documentation](https://docs.github.com/pages)
- Review GitHub Actions logs
- Test locally with `dotnet run`

---

## Alternative: Azure Static Web Apps

If you prefer Azure instead:

1. Create Azure Static Web App
2. Connect to GitHub repository
3. Azure will auto-detect Blazor and configure build
4. Deployment happens automatically on push

## Alternative: Netlify

1. Create account at [Netlify](https://www.netlify.com)
2. Drag and drop `wwwroot` folder
3. Update base href to `/`
4. Deploy

---

**Deployment Status**: Ready for GitHub Pages ✅
**Last Updated**: February 2026
