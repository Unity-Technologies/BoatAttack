#ifndef CROSSFADE_INCLUDED
#define CROSSFADE_INCLUDED

void LODCrossfade_float(float3 fadeMaskSeed, out float Out)
{
    LODDitheringTransition(fadeMaskSeed, unity_LODFade.x);
    Out = 1;
}

#endif

//////////////////////////////////////////////////////////////////////////////////////////////////////