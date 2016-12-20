import System.Environment (getArgs)
import Data.List

main = do
    [inpFile] <- getArgs    
    input <- readFile inpFile    
    mapM_ putStrLn $ map showLowestUniqueIndex $ lines input

showLowestUniqueIndex :: String -> String
showLowestUniqueIndex input = case result of Nothing -> "0"
                                             Just element -> show (element + 1)
    where result = lowestUniqueIndex input

lowestUniqueIndex ::  String -> Maybe Int
lowestUniqueIndex input = case lowestUniqueElement of Nothing -> Nothing
                                                      Just element -> elemIndex element initialList
    where lowestUniqueElement = firstUnique $ quicksort initialList
          initialList = toArrayOfNumbers input 
       

toArrayOfNumbers :: String -> [Int]
toArrayOfNumbers = (map read) . words   

firstUnique :: (Eq a) => [a] -> Maybe a
firstUnique [] = Nothing
firstUnique (x:xs) = if elem x xs 
                        then firstUnique $ filter (/=x) xs
                        else Just x

quicksort :: (Num a, Ord a) => [a] -> [a]
quicksort [] = []
quicksort (x:xs) =
    let smallerSorted = quicksort [a | a <- xs, a <= x]
        biggerSorted = quicksort [a | a <- xs, a > x]
        in smallerSorted ++ [x] ++ biggerSorted