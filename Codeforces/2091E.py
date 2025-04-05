nmax = 10000001
p=[]
isp=[True for i in range(nmax)]
p.append(0)
p.append(2)
for i in range(4,nmax,2):
 isp[i] = False
for i in range(3,nmax,2):
 if isp[i]:
  p.append(i)
  for j in range(i * i,nmax,i):
   isp[j]=False
p.append(nmax)

 
def solve(n):
 sum = 0
 for i in range(1,n+1):
  l = 0
  r = len(p)-1
  while(l + 1 < r):
   mid=(l+r)//2
   if p[mid]*i <= n:
    l=mid
   else:
    r=mid
  if l==0:
   break
  else:
   sum += l
 return sum

test = int(input())
for t in range(test):
 n = int(input())
 print(solve(n))

